// Custom scripts
$(document).ready(function () {
    // Collapse ibox function
    $('.collapse-link').click(function () {
        var ibox = $(this).closest('div.ibox');
        var button = $(this).find('i');
        var content = ibox.find('div.ibox-content');
        content.slideToggle(200);
        button.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
        ibox.toggleClass('').toggleClass('border-bottom');
        setTimeout(function () {
            ibox.resize();
            ibox.find('[id^=map-]').resize();
        }, 50);
    });

    // Close ibox function
    $('.close-link').click(function () {
        var content = $(this).closest('div.ibox');
        content.remove();
    });

    // Small todo handler
    $('.check-link').click(function () {
        var button = $(this).find('i');
        var label = $(this).next('span');
        button.toggleClass('fa-check-square').toggleClass('fa-square-o');
        label.toggleClass('todo-completed');
        return false;
    });

    // Append config box / Only for demo purpose
    //$.get("skin-config.html", function (data) {
    //    $('body').append(data);
    //});

    // minimalize menu
    $('.navbar-minimalize').click(function () {
        $("body").toggleClass("mini-navbar");
        SmoothlyMenu();
    })

    // tooltips
    $('.tooltip-demo').tooltip({
        selector: "[data-toggle=tooltip]",
        container: "body"
    })

    // Move modal to body
    // Fix Bootstrap backdrop issu with animation.css
    $('.modal').appendTo("body")

    // Full height of sidebar
    function fix_height() {
        var heightWithoutNavbar = $("body > #wrapper").height() - 61;
        $(".sidebard-panel").css("min-height", heightWithoutNavbar + "px");
    }
    fix_height();

    $(window).bind("load resize click scroll", function () {
        if (!$("body").hasClass('body-small')) {
            fix_height();
        }
    })

    $("[data-toggle=popover]")
        .popover();


    $('.ibox-content .checkAll').each(function () {
        $(this).click(function () {
            var checkAll = $(this);
            checkAll.parents('label').find('span').text(this.checked ? '取消' : '全选');
            var itemCheck = checkAll.parents('.ibox-content').find('.itemCheck');
            itemCheck.prop('checked', this.checked);
            itemCheck.each(function () {
                $(this).click(function () {
                    var ischeck = itemCheck.length == checkAll.parents('.ibox-content').find('.itemCheck:checked').length;
                    checkAll.prop('checked', ischeck);
                    checkAll.parents('label').find('span').text(ischeck ? '取消' : '全选');
                });
            })
        });
    });
});


// For demo purpose - animation css script
function animationHover(element, animation) {
    element = $(element);
    element.hover(
        function () {
            element.addClass('animated ' + animation);
        },
        function () {
            //wait for animation to finish before removing classes
            window.setTimeout(function () {
                element.removeClass('animated ' + animation);
            }, 2000);
        });
}

// Minimalize menu when screen is less than 768px
$(function () {
    $(window).bind("load resize", function () {
        if ($(this).width() < 769) {
            $('body').addClass('body-small')
        } else {
            $('body').removeClass('body-small')
        }
    })
})

function SmoothlyMenu() {
    if (!$('body').hasClass('mini-navbar') || $('body').hasClass('body-small')) {
        // Hide menu in order to smoothly turn on when maximize menu
        $('#side-menu').hide();
        // For smoothly turn on menu
        setTimeout(
            function () {
                $('#side-menu').fadeIn(500);
            }, 100);
    } else if ($('body').hasClass('fixed-sidebar')) {
        $('#side-menu').hide();
        setTimeout(
            function () {
                $('#side-menu').fadeIn(500);
            }, 300);
    } else {
        // Remove all inline style from jquery fadeIn function to reset menu state
        $('#side-menu').removeAttr('style');
    }
}

// Dragable panels
function WinMove() {
    var element = "[class*=col]";
    var handle = ".ibox-title";
    var connect = "[class*=col]";
    $(element).sortable(
        {
            handle: handle,
            connectWith: connect,
            tolerance: 'pointer',
            forcePlaceholderSize: true,
            opacity: 0.8,
        })
        .disableSelection();
}

function uploadfiy(options) {
    setTimeout(function () {
        var settings = { uploadID: '', url: '', callback: function () { }, fileTypeExts: '*.jpg;*.png;', width: 70, height: 34, buttonText: '上传', swf: '/Content/uploadify.swf' };

        options = options || {};
        $.extend(settings, options);
        settings.uploadID.uploadify({
            uploader: settings.url, // 服务器处理地址
            swf: settings.swf,
            buttonText: settings.buttonText, //按钮文字
            height: settings.height, //按钮高度
            width: settings.width, //按钮宽度
            //fileTypeExts: settings.fileTypeExts, //允许的文件类型
            //formData: { "imgType": "normal" }, //提交给服务器端的参数
            onInit: function (instance) { instance.button.find('.uploadify-button-text').prepend('<i class="fa fa-upload"></i>&nbsp;&nbsp;') },
            onUploadSuccess: function (file, data, response) { //一个文件上传成功后的响应事件处理
                var data = $.parseJSON(data);
                if ($.isFunction(settings.callback)) {
                    settings.callback.call(this, data);
                }
            }
        });
    }, 0);
}

function Page() {
    this.MultipleDel = function (obj, url) {
        obj.unbind("click").click(function () {
            var choose_objs = $('#purview_tb .i-checks:checked');
            if (choose_objs.length > 0) {
                bootbox.confirm("确认要删除记录吗?", function (result) {
                    if (result) {
                        var ids = new Array();
                        choose_objs.each(function () { ids.push($(this).val()); });
                        $.post(url, { ids: ids }, function (del_result) {
                            top.bootbox.alert(del_result.msg, function () { if (del_result.success) window.location.reload(); });
                        });
                    }
                });
            } else
                bootbox.alert('请选择记录');
        });
    };
    this.SingleDel = function (obj) {
        obj.unbind("click").click(function () {
            var url = $(this).attr('data-url');
            bootbox.confirm("确认要删除记录吗?", function (result) {
                if (result)
                    $.post(url, function (del_result) { bootbox.alert(del_result.msg, function () { if (del_result.success) window.location.reload(); }); });
            });
        });
    };
}

//判断输入的EMAIL格式是否正确 
function IsEmail(value) {
    this.value = value;
    var Emailvalue = trim(this.value);
    reg = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (reg.test(Emailvalue)) {
        return true;
    }
    return false;
}

//匹配非空的正则表达式
function IsEmpty(value) {
    this.value = value;
    var va = trim(this.value);
    reg1 = /.+/;
    if (reg1.test(va)) {
        return true;
    }
    return false;
}
//删除左右两端的空格
function trim(str) {
    if (str == undefined) {
        str = "";
    }
    return str.replace(/(^\s*)|(\s*$)/g, "");
}

