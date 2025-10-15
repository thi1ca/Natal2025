$(document).ready(function () {
    $('.navbar-toggler, .overlay-background, .close-overlay').click(function(){
        if ($(this).hasClass('collapsed')) {
            $('body').addClass('overflow-hidden');
            $('.navbar-collapse .overlay-background').css({'display': 'block'});
        }else{
            $('body').removeClass('overflow-hidden');
        }
    });
    $('.navbar-toggler, .overlay-background, .close-overlay').click(function(){
        $("body").css({"overflow-y": "auto"});
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

    $('.collapse').on('show.bs.collapse', function () {
        $(this).siblings('.sac .ganhadores .accordion .card .card-header').addClass('active');
    });

    $('.collapse').on('hide.bs.collapse', function () {
        $(this).siblings('.sac .ganhadores .accordion .card .card-header').removeClass('active');
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
        // $(".termos").addClass("vh-100");
        $(".termos .termo-privacidade").show();
    }

    var linkhome = "home";
    if (url_parts == linkhome) {
        $("main").addClass("bilhete");
        var entrouHome = localStorage.getItem('entrouHome');
        if (entrouHome === null) {
            // Se o usuário nunca entrou na home, mostrar o pop-up
            $(".home-pop .overlay-background").css({"display": "flex"});
            $("body").css({"overflow": "hidden"});
            // Gravar no localStorage que o usuário entrou na home
            localStorage.setItem('entrouHome', true);

            setInterval(function()
            {
                $('.home-pop .overlay-background').hide();
                $("body").css({"overflow-y": "auto"});
            }, 20000);
        }
    }
    var linkterms = "terms";
    if (url_parts == linkterms) {
        //$("main.mob").addClass("termos");
        $("main").addClass("termos");
        $(".termos .img-background").attr("src", "/assets/image/effects-bg-wth-blur.svg");
        // $(".termos").removeClass("vh-100");
    }
    var linktermsandprivacy = "termsandprivacy";
    if (url_parts == linktermsandprivacy) {
        $("main").addClass("termos");
        $(".termos .img-background").attr("src", "/assets/image/effects-bg-wth-blur.svg");
        // $(".termos").removeClass("vh-100");
    }
    var linkquest = "questions";
    if (url_parts == linkquest) {
        $("main").addClass("respos");
        $("main").removeClass("vh-100");
    }

    var linkapply = "apply-coupon";
    if (url_parts == linkapply) {
        $("main").addClass("apply-coupon");
    }

    var linkreceive = "receive-coupon";
    if (url_parts == linkreceive) {
        $("main").addClass("receive-coupon");
    }
    var linksac = "sac";
    if (url_parts == linksac) {
        $("main").removeClass("login");
        $("main").removeClass("vh-90");
        $(".img-background").hide();
    }
    var linkroulette = "roulette";
    if (url_parts == linkroulette) {
        $("main").addClass("overflow");
        $("main .container").addClass("vh-100");
    }

    var linkregister = "register";
    if (url_parts == linkregister) {
        $("main").addClass("register login vh-100");
        if ($("#ContentPlaceHolder1_tbNome").val() && $("#ContentPlaceHolder1_tbEmail").val() && $("#ContentPlaceHolder1_tbCelular").val()) {
            console.log("Preenchidos");
            $(".navbar-toggler").show();
        }else{
            console.log("Não Preenchidos");
            $(".navbar-toggler").hide();
        }
        $(".email").emailautocomplete({
            domains: ["example.com"] //add your own domains
        });
        $.validator.addMethod("alpha", function(value, element) {
            return this.optional(element) || value == value.match(/^[A-Za-zÀ-ú.\s]+$/);
        });
        $(".img-background").hide();


    }

    // Verificar o tamanho da tela e dos elementos
    var windowHeight = $(window).height();
    var elementosHeight = $('main .container').height(); 

    // Verificar se a altura da tela é menor que a altura dos elementos
    if (windowHeight < elementosHeight) {
        $("main").removeClass("vh-100");
    }else{
        $("main").addClass("vh-100");
    }


    setInterval(function()
	{
		$('.card-raspe .overlay-background').hide();
	}, 6000);

    $('.overlay-background').click(function(){
        $(this).hide();
    });

    // document.addEventListener('touchmove', function(e) {
    //     $('.card-raspe .overlay-background').hide();
    // }, false);
    
    // Máscara para campos de telefone
    var behavior = function (val) {
        return val.replace(/\D/g, '').length === 11 ? '(00) 00000-0000' : '(00) 0000-00009';
    },
    options = {
        onKeyPress: function (val, e, field, options) {
            field.mask(behavior.apply({}, arguments), options);
        }
    };
    
    $('.phones').mask(behavior, options);
    // $('.phones').mask('(00) 0000-00009');
    $('.money').mask('000.000.000.000.000,00', {reverse: true});
    $('.cpf').mask('000.000.000-00');
    $('.birthday').mask('00/00/0000');


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

    $('.name-winners span').text('•••••• •• ••••');

    var linkaccesscode = "accessCode";
    if (url_parts == linkaccesscode) {
        var viewStap = $('#ContentPlaceHolder1_divCodigo');
        // var newsrc="/assets/image/stap-01-start.svg";
        var newsrcte="/assets/image/stap-02-start.svg";
        var newsrccd="/assets/image/stap-03-start.svg";
        if (viewStap.length > 0) {
            $('.stap .number').parent().parent().parent().parent().parent().parent().children().children('i').addClass("orange-bg");
            $('.stap .number').parent().parent().parent().parent().parent().parent().children().children('i').children('img').attr("src", newsrccd);

            $('.stap .form-check-input input').parent().parent().parent().parent().children().children('i').addClass("orange-bg");
            $('.stap .form-check-input input').parent().parent().parent().parent().children().children('i').children('img').attr("src", newsrcte);
        }else{
            // console.log("Não tenho class");
        }
        // MASCARA PARA O CELULAR HTML
        var phoneTo = $("#ContentPlaceHolder1_labCelular").text();
        var phoneParts = phoneTo.split("");
        var numberStart = phoneParts.slice(0, 2).join("");
        var numberMiddle = phoneParts.slice(2, 5).join("");
        var numberEnd = phoneParts.slice(9, 11).join("");
        var numberEndBullets = "••-••" + numberEnd;
        var phoneBullets = "(" + numberStart + ")" + numberMiddle + numberEndBullets;
        $("#ContentPlaceHolder1_labCelular").text(phoneBullets);

        // MASCARA PARA O E-MAIL HTML
        var emailTo = $("#ContentPlaceHolder1_labEmail").text();
        var emailParts = emailTo.split("@");
        var username = emailParts[0];
        var domain = emailParts[1];
        var usernameBullets = username.slice(0, 5) + "•••••";
        var domainBullets = domain.slice(0, 4) + "••••";
        var emailBullets = usernameBullets + "@" + domainBullets;
        $("#ContentPlaceHolder1_labEmail").text(emailBullets);
    }

    var viewStap = $('.stap#ContentPlaceHolder1_divCodigo');
    if (viewStap.length > 0) {
        // console.log("Tenho class");
        $("main").removeClass("vh-100");
        setTimeout(function() { 
            $('.stap.stap-next .form-check-input').next("label").parent(".custom-radio:not(.select-not-fill)").hide();
            $('.stap.stap-next .form-check-input').next("label").parent(".custom-radio").parent(".warp-label").append("<a href='/accessCode' class='send-methe'>Selecione outro método de envio</a>");
        }, 500);
    }else{
        // console.log("Não tenho class");
    }

    var urlscratch = $(location).attr("href");
    var regexscratch = /\/scratch\?cupId=\d+/;
    var resultscratch = regexscratch.exec(urlscratch);

    if (resultscratch) {
        var interval = setInterval(function() {
            var viewCard = $('#js-canvas');
            if (viewCard.length) {
                $(".navbar-toggler").hide();
                console.log("Tenho class");
                clearInterval(interval);
            }else{
                $(".navbar-toggler").show();
                console.log("Não tenho class");
            }
        }, 1000);
        
    } else {
        // console.log("This is not a page with a cup id in the URL.");
    }

    var regexscratched = /\/scratched\?cupId=\d+/;
    var resultscratched = regexscratched.exec(urlscratch);
    if (resultscratched) {
        if ($('.swal2-popup').length > 0) {
            // Se a classe swal2-popup existe
            // $(".premio .position-relative").hide();
            $(".premio .position-relative").html('<img src="assets/image/time-clock.svg"><span class="mt-2 d-block nganhou">O seu código ainda não foi publicado, aguarde mais um tempo.</span>');
          } else {
            // Se a classe swal2-popup não existe
        }
        
    } else {
        // console.log("This is not a page with a cup id in the URL.");
    }



    $(".stap .form-check-input input:checked").parent().parent(".custom-radio").addClass("select-not-fill");
    $(".stap .form-check-input input:checked").parent().next().parent(".custom-radio").addClass("select-not-fill");
    $('.stap .form-check-input').change(function(){
        var pmValue = $('.stap .form-check-input input').is(':checked');
        $('.stap .form-check-input').next(".custom-control-label").addClass("not-fill");
        $('.stap .form-check-input').next().next(".custom-control-label").addClass("not-fill");
        $(this).next(".custom-control-label").removeClass("not-fill");
        $(this).next().next(".custom-control-label").removeClass("not-fill");

        if (! pmValue) {
            $('.stap .form-check-input').parent(".custom-radio").removeClass("select-not-fill");
            $('.stap .form-check-input').next().parent(".custom-radio").removeClass("select-not-fill");

        }else{
            $('.stap .form-check-input').parent(".custom-radio").removeClass("select-not-fill");
            $('.stap .form-check-input').next().parent(".custom-radio").removeClass("select-not-fill");
            $(this).parent(".custom-radio").addClass("select-not-fill");
            $(this).next().parent(".custom-radio").addClass("select-not-fill");
            $(".main").removeClass("vh-90");
            // alert("Ponto 01");
        }
        
    });
    $(".custom-switch input#ContentPlaceHolder1_terms_cbAceite").addClass("custom-control-input customSwitch");
    $(".custom-switch input#ContentPlaceHolder1_terms_cbAceite + label").addClass("custom-control-label text-blue");


    var timeLeft = 5 * 60; // 5 minutes in seconds
    var timer = setInterval(function() {
        var minutes = Math.floor(timeLeft / 60);
        var seconds = timeLeft % 60;
        var timeString = minutes + ":" + (seconds < 10 ? "0" + seconds : seconds);
        $("#timer-code").html("Expira em " + timeString + " minutos");
        if (timeLeft === 0) {
        clearInterval(timer);
        $("#timer-code").html("Reenvie o código novamente");
        }
        timeLeft--;
    }, 1000);


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
            $('.stap.stap-next .form-check-input').next().next("label").addClass("not-fill");
            $('.stap.stap-next .form-check-input').next().next("label").parent(".custom-radio").addClass("select-not-fill");
            $('.stap.stap-next .form-check-input').children("label").hide();
            $(".main").removeClass("vh-90");
            // alert("Ponto 02");
        } else {
            $('.stap.stap-next .form-check-input').next("label").removeClass("not-fill");
            $('.stap.stap-next .form-check-input').next("label").parent(".custom-radio").removeClass("select-not-fill");
            $('.stap.stap-next .form-check-input').next().next("label").removeClass("not-fill");
            $('.stap.stap-next .form-check-input').next().next("label").parent(".custom-radio").removeClass("select-not-fill");
            $('.stap .form-check-input input').parent().parent().parent().parent().addClass("stap-next");
            $('.stap .form-check-input input').parent().parent().parent().parent().children('button').hide();
            $('.stap .form-check-input input').parent().parent().parent().parent().children().children('i').addClass("orange-bg");
            $('.stap .form-check-input input').parent().parent().parent().parent().children().children('i').children('img').attr("src", newsrcte);
            $(".main").removeClass("vh-90");
            // alert("Ponto 03");
            
        }
        //validação do código
        if (codeValue === "") {
            $('.stap .number').parent().addClass("not-fill");
            $('.stap .number').prev().addClass("not-fill");
            $(".main").removeClass("vh-90");
            // alert("Ponto 04");
        } else if (codeValue.trim().length === 1){
            $('.stap .number').removeClass("not-fill");
            $('.stap .number').prev().removeClass("not-fill");
            $('.stap .number').parent().parent().parent().next().show();
            $('.stap .number').parent().parent().parent().parent().parent().parent().children().children('i').addClass("orange-bg");
            $('.stap .number').parent().parent().parent().parent().parent().parent().children().children('i').children('img').attr("src", newsrccd);
            $(".main").removeClass("vh-90");
            // alert("Ponto 05");
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
        $('#ContentPlaceHolder1_secretCode, #secret-code').select();
        try {
            var ok = document.execCommand('copy');
            if (ok) { 
                $("#ContentPlaceHolder1_secretCode, #secret-code").addClass("copy-select");
                $(".card-raspe .premio i").css('opacity', '1');
            }
            } catch (e) {
            alert(e)
        }
    });

    var linkindex = "index";
    if (url_parts == linkindex) {
        var usernames = localStorage.getItem("usernames");
        var userphones = localStorage.getItem("userphones");
        $("#ContentPlaceHolder1_butProximo").click(function() {
            var usernames = $("#ContentPlaceHolder1_tbCPF").val();
            var userphones = $("#ContentPlaceHolder1_tbCelular").val();
            localStorage.setItem("usernames", usernames);
            localStorage.setItem("userphones", userphones);
        });

        if (usernames) {
            $("#ContentPlaceHolder1_tbCPF").val(usernames);
            $("#ContentPlaceHolder1_tbCelular").val(userphones);
            $(".bt-cpf-incio h3").replaceWith("<h3 class='text-blue text-center'><strong>Que bom que você voltou!</strong><br> Confirme seu CPF e Celular e clique<br>no botão avançar!</h3>");
        }
    }

    
    // jQuery.validator.addMethod("alpha", function (value, element) {
    //     return this.optional(element) || /^[A-Za-zÀ-ú.\s]+$/.test(value);
    // }, "Please enter only alphabetical characters.");
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

    $(".register #ContentPlaceHolder1_butAvancar").click(function() {
        var form = $("#form1");
        form.validate({
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
    });
    
    $(".termos #ContentPlaceHolder1_butProximo").click(function() {
        var form = $(".termos #termo-priva");
        form.validate({
            rules : {
                ContentPlaceHolder1_cbAceite:{
                    required:true
                },                        
            },
            messages:{
                ContentPlaceHolder1_cbAceite:{
                    required:"Clique no aceite <img src='/assets/image/error.svg'>"
                }    
            }
        });
    });

    $("#ContentPlaceHolder1_butAvancar").click(function() {
        var form = $(".contactform");
        form.validate({
            rules : {
                ctl00$ContentPlaceHolder1$tbCelular:{
                    required:true
                },                        
            },
            messages:{
                ctl00$ContentPlaceHolder1$tbCelular:{
                    required:"Campo obrigatório <img src='/assets/image/error.svg'>"
                }    
            }
        });
    });
    
    var linkterms = "terms";
    if (url_parts == linkterms) {
        $('.termo-privacidade #regulamentos').scrollTop($('.termo-privacidade #regulamentos')[0].scrollHeight);
        $('.termo-privacidade #privacidade').scrollTop($('.termo-privacidade #privacidade')[0].scrollHeight);
        var startF = $('.termo-privacidade p:last-child'); 
        // $('.termo-privacidade #regulamentos, .termo-privacidade #privacidade').scrollTop($('#inicio').offset().top);


        $(window).on('touchmove', function() {
            $(".termo-privacidade #regulamentos, .termo-privacidade #privacidade").scroll(function() {
                var div_heigh = $(".termo-privacidade #regulamentos .envo, .termo-privacidade #privacidade .envo").height(); // pega a altura da div
                var win_heigh = window.innerHeight; // pega a altura da janela
                var win_scrol = $(this).scrollTop(); // pega o valor da rolagem da janela
                var div_topo  = $(".termo-privacidade #regulamentos .envo, .termo-privacidade #privacidade .envo").offset().top; // distância da div até o início do documento
                var distancia = div_topo - win_scrol - win_heigh; // distância da div até a borda inferior da janela
        
                if (distancia <= -div_heigh) {
                    console.log("foi");
                    $("#ContentPlaceHolder1_cbAceite").prop( "checked", true );
                }else{
                    $("#ContentPlaceHolder1_cbAceite").prop( "checked", false );
                }
        
            });
        });
    }
    // function detectar_mobile() { 
    //     if( navigator.userAgent.match(/Android/i)
    //     || navigator.userAgent.match(/webOS/i)
    //     || navigator.userAgent.match(/iPhone/i)
    //     || navigator.userAgent.match(/iPad/i)
    //     || navigator.userAgent.match(/iPod/i)
    //     || navigator.userAgent.match(/BlackBerry/i)
    //     || navigator.userAgent.match(/Windows Phone/i)
    //     ){
    //        console.log("mobile");
    //        $("main.mob ").show();
    //         $("main.desk ").hide();
    //         $("body").removeClass("desktop").addClass("mobile");
    //      }
    //     else {
    //         console.log("Computador");
    //         $("main.mob ").hide();
    //         $("main.desk ").show();
    //         $("body").removeClass("mobile").addClass("desktop");
    //      }
    //    }
    
    // detectar_mobile();

    // Mobile 
    // var isMobile = /Android|webOS|iPhone|iPod|BlackBerry/i.test(navigator.userAgent);
    // if ($(window).width() < 680 || isMobile) {
    //     console.log("mobile");
    //     $("main.mob ").show();
    //      $("main.desk ").hide();
    //      $("body").removeClass("desktop").addClass("mobile");
    // }else{
    //     console.log("Computador");
    //     $("main.mob ").hide();
    //     $("main.desk ").show();
    //     $("body").removeClass("mobile").addClass("desktop");
    // }

});

     // Mobile 
     var isMobile = /Android|webOS|iPhone|iPod|BlackBerry/i.test(navigator.userAgent);
     // Resize para Mobile
     $(window).resize(function() {
        // Verificar o tamanho da tela e dos elementos
        var windowHeight = $(window).height();
        var elementosHeight = $('main .container').height(); 

        // Verificar se a altura da tela é menor que a altura dos elementos
        if (windowHeight < elementosHeight) {
            $("main").removeClass("vh-100");
        }else{
            $("main").addClass("vh-100");
        }
        //  if ($(window).width() < 780 || isMobile) {
        //      console.log("mobile");
        //      $("main.mob ").show();
        //       $("main.desk ").hide();
        //       $("body").removeClass("desktop").addClass("mobile");
        //  }else{
        //      console.log("Computador");
        //      $("main.mob ").hide();
        //      $("main.desk ").show();
        //      $("body").removeClass("mobile").addClass("desktop");
        //  }
     });

