$('.js-action-hover').hover(function () {
    console.log("in");
    var $temp = $(this).find($('.overlay'));
    $temp.css('opacity', 1);
},
   function () {
       console.log("out");
       var $temp = $(this).find($('.overlay'));
       $temp.css('opacity', 0);
   })