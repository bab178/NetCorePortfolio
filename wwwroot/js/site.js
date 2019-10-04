/* =================================
------------------------------------
	Riddle - Portfolio
	Version: 1.0
 ------------------------------------ 
 ====================================*/
'use strict';
$(window).on('load', function () {
	/*------------------
		Preloader
	--------------------*/
    $(".loader").fadeOut();
    $("#preloader").delay(400).fadeOut("slow");
    if ($('.portfolios-area').length > 0) {
        var containerEl = document.querySelector('.portfolios-area');
        var mixer = mixitup(containerEl);
    }
});

(function ($) {
	/*------------------
		Navigation
	--------------------*/
    $('.nav-switch').on('click', function (event) {
        $('.main-menu').slideToggle(400);
        event.preventDefault();
    });

	/*----------------------
		Portfolio layout
	------------------------*/
    var port_fi = $('.portfolios-area .first-item'),
        port_si = $('.portfolios-area .second-item'),
        port_intro_h = $('.portfolio-intro').innerHeight();
    if ($(window).width() > 991) {
        port_fi.appendTo('.portfolio-intro');
        port_si.find('.portfolio-item').height(port_intro_h + 601);
    }

    $('.portfolio-item.pi-style2').each(function () {
        var pi_width = $(this).width();
        $(this).height(pi_width + 50);
    });

	/*------------------
		Accordions
	--------------------*/
    $('.panel-link').on('click', function (e) {
        $('.panel-link').parent('.panel-header').removeClass('active');
        var $this = $(this).parent('.panel-header');
        if (!$this.hasClass('active')) {
            $this.addClass('active');
        }
        e.preventDefault();
    });
})(jQuery);