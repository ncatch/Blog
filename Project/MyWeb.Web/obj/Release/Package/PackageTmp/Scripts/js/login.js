$(function () {

    if (getParam("a") == '0') {
        $('#switch_login').trigger('click');
    }

    $("#btn_login").click(function () {
        if ($("#username").val().trim() == "" || $("#username").val() == $("#username").attr("text")) {
            $("#Login_Tip").text("请输入用户名!");
            $("#username").focus();
            return;
        }
        else if ($("#userpwd").val().trim() == "" || $("#userpwd").val() == $("#userpwd").attr("text")) {
            $("#Login_Tip").text("请输入密码!");
            $("#userpwd").focus();
            return;
        }

        var maxwidth = $("body").width() - 20;

        big();//使用前面闪烁
        
        $("#bar").animate({ width: maxwidth * 7 / 10 }, function () {
            $("#bar_right").width("100px");
        });
        $("#bar_right").animate({ left: maxwidth * 7 / 10 });

        //登录请求
        $.post("/Home/Login", $("#login_form").serialize(), function (data) {
            $("#bar_right").animate();
            $("#bar").animate();

            $("#bar").animate({ width: maxwidth + "px" }, 1000, function () {
                if ($("#bar").width() >= maxwidth) {
                    $("#bar").animate({ opacity: "0.5" }, function () {
                        $("#bar_right").remove();
                        $("#bar").animate({ opacity: "0" }, function () {
                            $("#bar").remove();
                        });
                    });
                }
                else {
                    $("#bar_right").show();
                }
            });

            $("#bar_right").animate({ left: maxwidth - 97 + "px" }, 1000);

            if (data == "ok") {
                window.location.href = "/Home/Index?width=" + $("#bar").width();
            }
            else {
                $("html").html(data);
            }
        });
    });

    $(".inputstyle").focus(function () {
        if ($(this).val() == $(this).attr("text")) {
            $(this).val("");
        }
    }).blur(function () {
        if ($(this).val().trim() == "") {
            $(this).val($(this).attr("text"));
        }
    });

    $(".inputstyle[name='UserLoginPwd']").focus(function () {
        $(this).attr("type", "password");
    }).blur(function () {
        debugger;
        if ($(this).val().trim() == $(this).attr("text")) {
            $(this).attr("type", "text");
        }
    });
    
    $("#reuserpwd").focus(function () {
        $(this).attr("type", "password");
    }).blur(function () {
        if ($(this).val().trim() == $(this).attr("text")) {
            $(this).attr("type", "text");
        }
    });

    function big() {
        $("#bar_right").animate({ opacity: "0.2" }, 500, small);
    }

    function small() {
        $("#bar_right").animate({ opacity: "1" }, 500, big);
    }
});




//根据参数名获得该参数 pname等于想要的参数名 
function getParam(pname) { 
    var params = location.search.substr(1); // 获取参数 平且去掉？ 
    var ArrParam = params.split('&'); 
    if (ArrParam.length == 1) { 
        //只有一个参数的情况 
        return params.split('=')[1]; 
    } 
    else { 
         //多个参数参数的情况 
        for (var i = 0; i < ArrParam.length; i++) { 
            if (ArrParam[i].split('=')[0] == pname) { 
                return ArrParam[i].split('=')[1]; 
            } 
        } 
    } 
} 