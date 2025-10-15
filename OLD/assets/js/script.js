$(document).ready(function () {
    $('.navbar-toggler, .overlay-background').click(function(){
        if ($(this).hasClass('collapsed')) {
            $('body').addClass('overflow-hidden');
        }else{
            $('body').removeClass('overflow-hidden');
        }
    });
    $('.filter-ticket button, .filter-ticket a').click(function(){
        $(".content-filter").children().children().removeClass("show");
        $('.filter-ticket button, .filter-ticket a').removeClass("active");
        $(this).addClass("active");
    });
    $('.filter-ticket button[data-target="#regulamentos"]').click(function(){
        $("#privacidade").hide();
        $("#regulamentos").show();
    });
    $('.filter-ticket button[data-target="#privacidade"]').click(function(){
        $("#regulamentos").hide();
        $("#privacidade").show();
    });
    
    var url = location.href;
    var url_parts = url.replace(/\/\s*$/,'').split('/').pop(); 
    var links = "termos-privacidade.html#approved";
    var linksopen = "termos-privacidade.html";
    var links2 = "termos-privacidade#approved";
    var linksopen2 = "termos-privacidade";
    // console.log(url_parts)

    if (url_parts == links || url_parts == links2) {
        $('.termos .custom-switch, .termos .btn-primary, .termos .voltar-login').hide();
        $('button.navbar-toggler').show();
    }else if(url_parts == linksopen || url_parts == linksopen2){
        $('.termos .custom-switch, .termos .btn-primary, .termos .voltar-login').show();
        $('button.navbar-toggler').hide();
    }

    var linkperfil = "perfil.html#approved";
    var linkperfilopen = "perfil.html?";
    var linkperfil2 = "perfil#approved";
    var linkperfilopen2 = "perfil";

    if (url_parts == linkperfil || url_parts == linkperfil2) {
        $('button.navbar-toggler').show();
    }else if(url_parts == linkperfilopen || url_parts == linkperfilopen2){
        $('button.navbar-toggler').hide();
    }

    if (url_parts == "meus-bilhetes.html" || url_parts == "meus-bilhetes" || url_parts == "meus-bilhetes.html?") {
        $("header .navbar-collapse .navbar-nav .nav-item:nth-of-type(2) a").addClass("active");
    }else if(url_parts == "ganhadores.html" || url_parts == "ganhadores"){
        $("header .navbar-collapse .navbar-nav .nav-item:nth-of-type(3) a").addClass("active");
    }else if(url_parts == "como-aplicar.html" || url_parts == "como-aplicar"){
        $("header .navbar-collapse .navbar-nav .nav-item:nth-of-type(4) a").addClass("active");
    }else if(url_parts == "termos-privacidade.html#approved" || url_parts == "termos-privacidade#approved"){
        $("header .navbar-collapse .navbar-nav .nav-item:nth-of-type(5) a").addClass("active");
        $(".termos").addClass("vh-100");
        $(".termos .termo-privacidade").css({"height":"410px"});
    }

    var linkterms = "terms";
    if (url_parts == linkterms) {
        $("main").addClass("termos");
        $(".termos .img-background").attr("src", "/assets/image/effects-bg-wth-blur.svg");
        $(".termos").removeClass("vh-90");
    }

    var linkquest = "questions";
    if (url_parts == linkquest) {
        $("main").addClass("respos");
    }

    var linkquest = "register";
    if (url_parts == linkquest) {
        $("main").addClass("register");
    }

    var linkapply = "apply-coupon";
    if (url_parts == linkapply) {
        $("main").addClass("apply-coupon");
    }

    var linkreceive = "receive-coupon";
    if (url_parts == linkreceive) {
        $("main").addClass("receive-coupon");
    }

    setInterval(function()
	{
		$('.card-raspe .overlay-background').hide();
	}, 8000);

    $('.card-raspe .overlay-background').click(function(){
        $(this).hide();
    });

    document.addEventListener('touchmove', function(e) {
        $('.card-raspe .overlay-background').hide();
    }, false);
    
    // Máscara para campos de telefone
    $('.phones').mask('(00) 0000-00009');
    $('.money').mask('000.000.000.000.000,00', {reverse: true});
    $('.cpf').mask('000.000.000-00');


    // Visualizar senhas
    $(this).attr('data-click-state', 1);
    $('.eye').on('click',function(){
        var input = $("#senha, #senhaRec");
        if($(this).attr('data-click-state') == 1) {
            $(this).attr('data-click-state', 0);
            $(this).attr("src", "/assets/image/eye-hover.svg");
            $(this).parent(".has-float-label").children("input").attr("type", "text");
            $(input).value = $(input).value;
        }else {
            $(this).attr('data-click-state', 1);
            $(this).attr("src", "/assets/image/eye.svg");
            $(this).parent(".has-float-label").children("input").attr("type", "password");
            $(input).value = $(input).value;
        }
    });

    // Tratamento de campos de entrada numérica com hífens
    $('.number').on('input', function (event) {
        var input = $(this);
        var myLength = input.val().trim().length;

        if (myLength === 1) {
            input.parent().parent().next('div.box-number').find('input').focus();
            input.next('.number').val('');
        }
    }).keydown(function (event) {
        if (event.key === "Backspace" || event.key === "Delete") {
            var input = $(this);
            input.val('');

            var myLength = input.val().trim().length;
            if (myLength === -1, 1) {
                input.parent().parent().prev('div.box-number').find('input').focus();
                input.next('.number').val('');
            }

            event.preventDefault();
        }
    });

    $('.mask-phone span').mask('(00) 00000-');
    $('.mask-phone span + span').text('-••••••');
    $('.mask-email span').mask('AAAA');
    $('.mask-email span + span').text('••••••@');
    $('.mask-email span + span + i').mask('AAAAAAAAAA');
    $('.mask-email span + span + i + i').text('••••••');
    $('.name-winners span').text('•••••• •• ••••');

    $('.stap .form-check-input').change(function(){
        $('.stap .form-check-input').next(".custom-control-label").addClass("not-fill");
        $('.stap .form-check-input').next().next(".custom-control-label").addClass("not-fill");
        $(this).next(".custom-control-label").removeClass("not-fill");
        $(this).next().next(".custom-control-label").removeClass("not-fill");
    });
    $(".custom-switch input#ContentPlaceHolder1_cbAceite").addClass("custom-control-input customSwitch");
    $(".custom-switch input#ContentPlaceHolder1_cbAceite + label").addClass("custom-control-label text-white");

    

    // $(".email").emailautocomplete({
    //     domains: ["example.com"] //add your own domains
    // });

    $(".bt-step").click(function() {
        // var cpfValue = $('.stap #ContentPlaceHolder1_tbCPF').val();
        var phonemailValue = $('.stap .form-check-input input').is(':checked');
        var codeValue = $('.stap .box-number:last-child').children().children().val();
        // var newsrc="/assets/image/stap-01-start.svg";
        var newsrcte="/assets/image/stap-02-start.svg";
        var newsrccd="/assets/image/stap-03-start.svg";
        var form = $("#form1");
        form.validate({
            rules : {
                // cpf:{
                //     required:true,
                //     minlength:14
                // },
                ctl00$ContentPlaceHolder1$CodAcesso:{
                    required:true
                },
                ctl00$ContentPlaceHolder1$tbNumAcesso1:{
                    required:true,
                    number:true,
                    minlength:1
                },
                ctl00$ContentPlaceHolder1$tbNumAcesso2:{
                    required:true,
                    number:true,
                    minlength:1
                } ,
                ctl00$ContentPlaceHolder1$tbNumAcesso3:{
                    required:true,
                    number:true,
                    minlength:1
                } ,
                ctl00$ContentPlaceHolder1$tbNumAcesso4:{
                    required:true,
                    number:true,
                    minlength:1
                }                         
            },
            messages:{
                // cpf:{
                //     required:"Informe seu cpf <img src='/assets/image/error.svg'>",
                //     minlength:"14 caracteres <img src='/assets/image/error.svg'>"
                // },
                ctl00$ContentPlaceHolder1$CodAcesso:{
                    required:" "
                },
                ctl00$ContentPlaceHolder1$tbNumAcesso1:{
                    required:" ",
                    minlength:" "
                },
                ctl00$ContentPlaceHolder1$tbNumAcesso2:{
                    required:" ",
                    minlength:" "
                },
                ctl00$ContentPlaceHolder1$tbNumAcesso3:{
                    required:" ",
                    minlength:" "
                },
                ctl00$ContentPlaceHolder1$tbNumAcesso4:{
                    required:" ",
                    minlength:" "
                }   
            }
        });
        //validação do CPF
        // if (cpfValue === "" || cpfValue.trim().length < 14){
        //     // $('.stap .cpf').addClass("not-fill");
        //     // $('.stap .cpf').prev().addClass("not-fill");
        //     // $('.stap .cpf').parent().addClass("not-fill");
        // }else if (cpfValue.trim().length >= 14){
        //     // $('.stap .cpf').removeClass("not-fill");
        //     // $('.stap .cpf').prev().removeClass("not-fill");
        //     // $('.stap .cpf').parent().removeClass("not-fill");
        //     $('.stap .cpf').parent().parent().next().addClass("stap-next");
        //     $('.stap .cpf').parent().parent().children('button').hide();
        //     $('.stap .cpf').parent().parent().children().children('i').addClass("orange-bg");
        //     $('.stap .cpf').parent().parent().children().children('i').children('img').attr("src", newsrc);
        // }
        //validação escolha de email e telefone
        if (! phonemailValue) {
            $('.stap.stap-next .form-check-input').next("label").addClass("not-fill");
            $('.stap.stap-next .form-check-input').next().next("label").addClass("not-fill");
            $('.stap.stap-next .form-check-input').children("label").hide();
            $(".main").removeClass("vh-90");
        } else {
            $('.stap.stap-next .form-check-input').next("label").removeClass("not-fill");
            $('.stap.stap-next .form-check-input').next().next("label").removeClass("not-fill");
            $('.stap .form-check-input input').parent().parent().parent().parent().addClass("stap-next");
            $('.stap .form-check-input input').parent().parent().parent().parent().children('button').hide();
            $('.stap .form-check-input input').parent().parent().parent().parent().children().children('i').addClass("orange-bg");
            $('.stap .form-check-input input').parent().parent().parent().parent().children().children('i').children('img').attr("src", newsrcte);
            $(".main").removeClass("vh-90");
        }
        //validação do código
        if (codeValue === "") {
            $('.stap .number').parent().addClass("not-fill");
            $('.stap .number').prev().addClass("not-fill");
            $(".main").removeClass("vh-90");
        } else if (codeValue.trim().length === 1){
            $('.stap .number').removeClass("not-fill");
            $('.stap .number').prev().removeClass("not-fill");
            $('.stap .number').parent().parent().parent().next().show();
            $('.stap .number').parent().parent().parent().parent().parent().parent().children().children('i').addClass("orange-bg");
            $('.stap .number').parent().parent().parent().parent().parent().parent().children().children('i').children('img').attr("src", newsrccd);
            $(".main").removeClass("vh-90");
        }

    });

    $(".filtro-linha").css('opacity', '0.3');
    $('.filtro-box').click(function(){
        $(".ganhadores").removeClass("flex-column");
        $(".ganhadores").addClass("flex-row");
        $(".filtro-linha").css('opacity', '1');
        $(".filtro-box").css('opacity', '0.3');
    });
    $('.filtro-linha').click(function(){
        $(".ganhadores").removeClass("flex-row");
        $(".ganhadores").addClass("flex-column");
        $(".filtro-box").css('opacity', '1');
        $(".filtro-linha").css('opacity', '0.3');
    });

    $('.copy').click(function(){
        $('#secret-code').select();
        try {
            var ok = document.execCommand('copy');
            if (ok) { 
                $("#secret-code").addClass("copy-select");
                $(".card-raspe .premio i").css('opacity', '1');
            }
            } catch (e) {
            alert(e)
        }
    });

    $.validator.addMethod("alpha", function(value, element) {
        return this.optional(element) || value == value.match(/^[A-Za-zÀ-ú.\s]+$/);
        // --                                    or leave a space here ^^
    });
    // $.validator.addMethod("email", function(value, element) {
    //     return this.optional(element) || value == value.match(/^[^@\\s]+@([^@\\s]+\\.)+[^@\\s]+$/);
    // });

    //Cursor iniciar no final da imput
    $('input').click(function(){
        $(this).value = $(this).value;
    });

    $(".bt-cpf-incio #ContentPlaceHolder1_butProximo").click(function() {
        var form = $("#form1");
        form.validate({
            rules : {
                ctl00$ContentPlaceHolder1$tbCPF:{
                    required:true,
                    minlength:14
                }                     
            },
            messages:{
                ctl00$ContentPlaceHolder1$tbCPF:{
                    required:"Informe seu cpf <img src='/assets/image/error.svg'>",
                    minlength:"14 caracteres <img src='/assets/image/error.svg'>"
                }   
            }
        });
    });
    
    $("#form_login").validate({
        rules : {
            cpf:{
                required:true,
                minlength:14
            },
            senha:{
                required:true,
                minlength:6
            }                          
        },
        messages:{
            cpf:{
                required:"Informe seu cpf <img src='/assets/image/error.svg'>",
                minlength:"14 caracteres <img src='/assets/image/error.svg'>"
            },
            senha:{
                required:"Informar a senha <img src='/assets/image/error.svg'>",
                minlength:"6 catacteres <img src='/assets/image/error.svg'>"
            }     
        }
    });
    $("#form_trocasenha").validate({
        rules : {
            senha:{
                required:true,
                minlength:6
            },
            senhaRec:{
                required:true,
                minlength:6,
                equalTo: "#senha"
            }                          
        },
        messages:{
            senha:{
                required:"Informar a senha <img src='/assets/image/error.svg'>",
                minlength:"6 catacteres <img src='/assets/image/error.svg'>"
            },
            senhaRec:{
                required:"Informar a senha <img src='/assets/image/error.svg'>",
                minlength:"6 catacteres <img src='/assets/image/error.svg'>",
                equalTo: "Mesma senha acima <img src='/assets/image/error.svg'>"
            }     
        }
    });
    $("#primeiro_acesso").validate({
        rules : {
            cpf:{
                required:true,
                minlength:14
            }                        
        },
        messages:{
            cpf:{
                required:"Informe seu cpf <img src='/assets/image/error.svg'>",
                minlength:"14 caracteres <img src='/assets/image/error.svg'>"
            }    
        }
    });
    $("#resposta_valida").validate({
        rules : {
            customRadioInline:{
                required:true
            }                        
        },
        messages:{
            customRadioInline:{
                required:"<img src='/assets/image/error.svg'> Selecione 1 opção"
            }    
        }
    });
    
    $(".register form").validate({
        rules : {
            ctl00$ContentPlaceHolder1$tbNome:{
                required:true,
                alpha: true,
                minlength: 5
            },
            ctl00$ContentPlaceHolder1$tbEmail:{
                required:true,
                email: true
            },
            ctl00$ContentPlaceHolder1$tbCelular:{
                required:true
            }                    
        },
        messages:{
            ctl00$ContentPlaceHolder1$tbNome:{
                required:"Campo obrigatório <img src='/assets/image/error.svg'>",
                alpha:"Apenas letras <img src='/assets/image/error.svg'>",
                minlength: "5 caracteres <img src='/assets/image/error.svg'>"
            },
            ctl00$ContentPlaceHolder1$tbEmail:{
                required:"Campo obrigatório <img src='/assets/image/error.svg'>",
                email: "E-mail inválido <img src='/assets/image/error.svg'>"
            },
            ctl00$ContentPlaceHolder1$tbCelular:{
                required:"Campo obrigatório <img src='/assets/image/error.svg'>"
            }    
        }
    });
    //$('.termo-privacidade').scrollTop($('.termo-privacidade')[0].scrollHeight);

    $("#termo-priva").validate({
        rules : {
            customSwitch:{
                required:true
            },                        
        },
        messages:{
            customSwitch:{
                required:"Clique no aceite <img src='/assets/image/error.svg'>"
            }    
        }
    });
    
    var startF = $('.termo-privacidade p:last-child'); 
    $('.termo-privacidade').scrollTop($('#inicio').offset().top);


    $(window).on('touchmove', function() {
        $(".termo-privacidade").scroll(function() {
            var div_heigh = $(".termo-privacidade .envo").height(); // pega a altura da div
            var win_heigh = window.innerHeight; // pega a altura da janela
            var win_scrol = $(this).scrollTop(); // pega o valor da rolagem da janela
            var div_topo  = $(".termo-privacidade .envo").offset().top; // distância da div até o início do documento
            var distancia = div_topo - win_scrol - win_heigh; // distância da div até a borda inferior da janela
    
            if (distancia <= -div_heigh) {
                console.log("foi");
                $("#customSwitch").prop( "checked", true );
            }else{
                $("#customSwitch").prop( "checked", false );
            }
    
        });
    });


    

    // // Mobile 
    // var isMobile = /Android|webOS|iPhone|iPod|BlackBerry/i.test(navigator.userAgent);
    // if ($(window).width() < 680 || isMobile) {

        
    // }else{


    // }
});

 

// Mobile 
var isMobile = /Android|webOS|iPhone|iPod|BlackBerry/i.test(navigator.userAgent);
// Resize para Mobile
$(window).resize(function() {

});