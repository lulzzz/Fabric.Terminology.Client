var gulp = require("gulp");
var replace = require('gulp-replace');
var fs = require('fs');
var xmlpoke = require('gulp-xmlpoke');
var assemblyInfo = require('gulp-dotnet-assembly-info');
var argv = require('yargs').argv;

var version = new function () {
    // Change these to set the assembly version
    this.releaseComment = "alpha";
    this.major = 0;
    this.minor = 4;
    this.patch = 1; // changing this will reset the build number in local

    // do not assign. 
    this.build = argv.buildNumber === undefined ? -1 : argv.buildNumber;
    this.compose = function () { return this.major + "." + this.minor + "." + this.patch + "." + this.build }
    this.nugetVersion = function () {
        var packageVersion = this.major + "." + this.minor + "." + this.patch;
        if (this.releaseComment !== '') { packageVersion += "-" + this.releaseComment; }
        if (this.releaseComment === '' && this.build !== -1 && this.build !== 0) { packageVersion += '.'; }
        if (this.build !== -1 && this.build !== 0) { packageVersion += this.build; }
        return packageVersion;
    }
};

/*************************************************************
 * Versioning
 * triggered via gulp script params:
 * e.g.  gulp prod --setVersion
 *       gulp prod --setVersion --buildNumber=[BUILD_NUMBER from VS BUILD]
 *************************************************************/
gulp.task("version", ["version:nuspec", "version:comment"], () => {
    if (argv.setVersion === undefined) { return; }

    saveInfo(getInfo("../Fabric.Terminology.Client/properties/"));
    saveInfo(getInfo("../Fabric.Terminology.Client.462/properties/"));

    function getInfo(infoFilePath) {
        var infoFile = infoFilePath + "AssemblyInfo.cs";
        var fileContents = fs.readFileSync(infoFile, "utf8");
        var assembly = assemblyInfo.getAssemblyMetadata(fileContents);
        var fileVersion = assembly.AssemblyVersion.split(".");
        assembly.parsedVersion = {
            major: fileVersion[0] * 1,
            minor: fileVersion[1] * 1,
            patch: fileVersion[2] * 1,
            build: fileVersion[3] * 1
        };
        assembly.savePath = infoFilePath;
        return assembly;
    }

    function saveInfo(ddlInfo) {
        if (version.patch !== ddlInfo.parsedVersion.patch || version.build === -1) {
            version.build = ddlInfo.parsedVersion.build;
        }
        var info = {
            title: "Fabric.Terminology.Client",
            description: "C# .NET client for the Fabric.Terminology.API.",
            configuration: "",
            company: "Health Catalyst",
            product: "Fabric.Terminology.Client",
            copyright: "Copyright " + new Date().getFullYear() + " \u00A9 Health Catalyst",
            trademark: "",
            culture: "",
            version: version.compose(),
            fileVersion: version.compose(),
            guid: ddlInfo.Guid
        };
        var infoFile = ddlInfo.savePath + "AssemblyInfo.cs";
        gulp.src(infoFile)
            .pipe(assemblyInfo(info))
            .pipe(gulp.dest(ddlInfo.savePath));
    }
});

gulp.task("version:comment",
    () => {
        if (argv.setVersion === undefined) { return; }
        gulp.src("../Fabric.Terminology.API/Configuration/TerminologyVersion.cs")
            .pipe(replace(/CurrentComment *(=>) *(.+)/g, "CurrentComment => \"" + version.releaseComment + "\";"))
            .pipe(gulp.dest("../Fabric.Terminology.API/Configuration/"));
    });

gulp.task("version:nuspec",
    () => {
        console.info('Updating NuSpec Version to: ' +  version.nugetVersion());
        gulp.src('Fabric.Terminology.Client.nuspec')
            .pipe(xmlpoke({
                replacements: [{
                    xpath: "//nuspec:package/nuspec:metadata/nuspec:version"
                    , namespaces: { "nuspec": "http://schemas.microsoft.com/packaging/2012/06/nuspec.xsd" }
                    , value: version.nugetVersion()
                }]
            }))
            .pipe(gulp.dest('.'));
    });