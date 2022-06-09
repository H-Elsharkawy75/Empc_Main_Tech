$(document).ready(function()
{

    
            // fixed element section Sticky
		$(window).on('scroll',function() {
            if ($(this).scrollTop() > 10){  

                $('.header').addClass("stikeyHeader");
            }
            else{
                $('.header').removeClass("stikeyHeader");
            }
});

	

	



});