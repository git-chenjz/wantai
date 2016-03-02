(function($){
    $.fn.ckSlide = function(opts){
        opts = $.extend({}, $.fn.ckSlide.opts, opts);
        this.each(function(){
            var slidewrap = $(this).find('.slide-wrapper');
            var slide = slidewrap.find('li');
            var count = slide.length;
            var that = this;
            var index = 0;
            var time = null;
            $(this).data('opts', opts);
            // next
            // $(this).find('.ck-next').on('click', function(){
            //     if(opts['isAnimate'] == true){
            //         return;
            //     }
                
            //     var old = index;
            //     if(index >= count - 1){
            //         index = 0;
            //     }else{
            //         index++;
            //     }
            //     change.call(that, index, old);
            // });
            // // prev
            // $(this).find('.ck-prev').on('click', function(){
            //     if(opts['isAnimate'] == true){
            //         return;
            //     }
                
            //     var old = index;
            //     if(index <= 0){
            //         index = count - 1;
            //     }else{                                      
            //         index--;
            //     }
            //     change.call(that, index, old);
            // });
            $(this).find('.slide-box li').each(function(cindex){
                $(this).on('click.slide-box', function(){
                    change.call(that, cindex, index);
                    index = cindex;

                });
            });
            
            // focus clean auto play
            $(this).on('mouseover', function(){
                if(opts.autoPlay){
                    clearInterval(time);
                }
                $(this).find('.ctrl-slide').css({opacity:0.6});
            });
            //  leave
            $(this).on('mouseleave', function(){
                if(opts.autoPlay){
                    startAtuoPlay();
                }
                $(this).find('.ctrl-slide').css({opacity:0.15});
            });
            startAtuoPlay();
            // auto play
            function startAtuoPlay(){
                if(opts.autoPlay){
                    time  = setInterval(function(){
                        var old = index;
                        if(index >= count - 1){
                            index = 0;
                        }else{
                            index++;
                        }
                        change.call(that, index, old);
                    }, 2000);
                }
            }
            // 修正box
            var box = $(this).find('.slide-box');
            // box.css({
            //     'margin-left':-(box.width() / 2)
            // })
            // dir
            // switch(opts.dir){
            //     case "x":
            //         opts['width'] = $(this).width();
            //         slidewrap.css({
            //             'width':count * opts['width']
            //         });
            //         slide.css({
            //             'float':'left',
            //             'position':'relative'
            //         });
            //         slidewrap.wrap('<div class="ck-slide-dir"></div>');
            //         slide.show();
            //         break;
            // }
        });
    };
    function change(show, hide){
        var opts = $(this).data('opts');

        $(this).find('.slide-wrapper li').eq(hide).stop().animate({opacity:0}, 1000);
        $(this).find('.slide-wrapper li').eq(show).show().css({opacity:0}).stop().animate({opacity:1}, 1000);

       
        $(this).find('.slide-box li').removeClass('current').stop().animate({"margin-top" : "0px"});
        $(this).find('.slide-box li').eq(show).addClass('current').stop().animate({"margin-top" : "0px"});
    }
    $.fn.ckSlide.opts = {
        autoPlay: false,
        dir: null,
        isAnimate: false
    };
})(jQuery);