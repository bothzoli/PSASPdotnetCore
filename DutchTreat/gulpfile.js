const gulp = require('gulp');
const uglify = require('gulp-uglify');
const concat = require('gulp-concat');

function minify() {
	return gulp.src('wwwroot/js/**/*.js')
		.pipe(uglify())
		.pipe(concat('dutchtreat.min.js'))
		.pipe(gulp.dest('wwwroot/dist'));
}

exports.default = gulp.series(minify);