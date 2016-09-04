var gulp = require("gulp"),
      browserSync = require('browser-sync').create();
      sass = require("gulp-sass"),
      autoprefixer = require('gulp-autoprefixer'),
      // Node modules
      del = require("del"),
      useref = require("gulp-useref"),
      uglify = require("gulp-uglify"),
      gulpIf = require("gulp-if"),
      runSequence = require('run-sequence'),
       Promise = require('es6-promise').Promise;

gulp.task("server", function() {

	browserSync.init({
		server: "src/"
	})
})

gulp.task("css", function() {

	return gulp.src("src/sass/main.scss")
		.pipe(sass())
		.pipe(autoprefixer({
			browsers: ['last 7 versions', 'IE 9'],
			cascade: false
		}))
		.pipe(gulp.dest("src/css/"))
		.pipe(browserSync.stream());

});

gulp.task("watch", function() {

	gulp.watch("src/sass/**/*.scss",  ["css"]);
	gulp.watch(["src/*.html", "src/**/*.js" ], browserSync.reload);

});


gulp.task("clean", function(){

	return del("dist/");

});

gulp.task("html", function(){

	return gulp.src("src/*.html")
		.pipe(useref())
		.pipe(gulpIf("*.js", uglify() ) )
		.pipe(gulp.dest("dist/"));

});

gulp.task("copy", function(){

	return gulp.src(["src/css/**/*.css" , "src/img"], {
		base: "src"
	})
	.pipe(gulp.dest("dist/"));

});

gulp.task("build", function(cb) {

	runSequence("clean", "html" , "copy", cb);

});

gulp.task("build:server",  ["build"], function() {

	browserSync.init({
		server: "dist/"
	});

});

gulp.task("default", ["css", "server", "watch"])