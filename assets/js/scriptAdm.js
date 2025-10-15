$(document).ready(function () {
    // Esconder os campos de input de email e telefone inicialmente
    $('.input-email').hide();

    $(".custom-switch input#ContentPlaceHolder1_cbTACC").addClass("custom-control-input");
    // $(".custom-switch input#ContentPlaceHolder1_cbTACC + label").addClass("custom-control-label");

    // Alternar entre email e telefone
    $(".select-radio input[type=radio]").click(function () {
        var radioValue = $('input[type=radio]:checked').val();

        if (radioValue === "Telefone") {
            $('.input-email').hide();
            $('.input-phone').show().find('input').val("");
        } else if (radioValue === "E-mail") {
            $('.input-email').show().find('input').val("");
            $('.input-phone').hide().find('input').val("");
        }
    });

    // Máscara para campos de telefone
    $('.phones').mask('(00) 0000-00009');
    $('.money').mask('000.000.000.000.000,00', {reverse: true});
    $('.cpf').mask('000.000.000-00', {reverse: true});
    $('#tbCPF').mask('000.000.000-00', {reverse: true});
    $('.time').mask('00:00:00', {reverse: true});

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

    var url = location.href;
    var url_parts = url.replace(/\/\s*$/,'').split('/').pop(); 

    var linkdashboard = "dashboard";
    if (url_parts == linkdashboard) {
        $("header .navbar-collapse .navbar-nav .nav-item:nth-child(2)").addClass("active");
    }
    var linkadmCampaigns = "admCampaigns";
    if (url_parts == linkadmCampaigns) {
        $("header .navbar-collapse .navbar-nav .nav-item:nth-child(3)").addClass("active");
    }
    var linkadmPrizes = "admPrizes";
    if (url_parts == linkadmPrizes) {
        $("header .navbar-collapse .navbar-nav .nav-item:nth-child(4)").addClass("active");
    }
    var linkadmCalendars = "admCalendars";
    if (url_parts == linkadmCalendars) {
        $("header .navbar-collapse .navbar-nav .nav-item:nth-child(5)").addClass("active");
    }
    var linkadmWinners = "admWinners";
    if (url_parts == linkadmWinners) {
        $("header .navbar-collapse .navbar-nav .nav-item:nth-child(6)").addClass("active");
        var interval = setInterval(function() {
            $(".custom-switch input#ContentPlaceHolder1_cbPendentes").addClass("custom-control-input customSwitch");
            $(".custom-switch input#ContentPlaceHolder1_cbPendentes + label").addClass("custom-control-label");
        }, 1000);
    }
    var linkadmClients = "admClients";
    if (url_parts == linkadmClients) {
        $("header .navbar-collapse .navbar-nav .nav-item:nth-child(7)").addClass("active");
    }
    var linkadmUsers = "admUsers";
    if (url_parts == linkadmUsers) {
        $("header .navbar-collapse .navbar-nav .nav-item:nth-child(8)").addClass("active");
    }
    var linkadmGraphs = "admGraphs";
    if (url_parts == linkadmGraphs) {
        $("header .navbar-collapse .navbar-nav .nav-item:nth-child(9)").addClass("active");
    }

    var linkcupomdelojareal = "cupomdelojareal";
    if (url_parts == linkcupomdelojareal) {
        $(".banner-full").addClass("d-none");
    }

    var linkadmCampaigns = "admCampaigns";
    if (url_parts == linkadmCampaigns) {
        // localStorage.clear();
        // localStorage.removeItem("clickHistory");
        // alert("foi");
    }
    // var intervalId = setInterval(function() {
    //     var inputNEW = $("#modalCadastra input");
    //     if (inputNEW.val().trim().length > 0) {
    //         console.log("Tenho texto nos campos");
    //         if($("#modalCadastra").hasClass(".show")){
    //             // $("#modalCadastra").modal('hide');
    //             intervalId();
    //         }else{
    //             $("#modalCadastra").modal('show');
    //             clearInterval(intervalId);
    //         }
            
    //     } else {
    //         console.log("Não tenho texto nos campos");
    //     }
    // }, 3000);
    // intervalId();



    // var intervalId;
    // function checkInput() {
    //     var inputNEW = $("#modalCadastra input");
    //     if (inputNEW.val().trim().length > 0) {
            
    //         console.log("Tenho texto nos campos");
    //         $("#modalCadastra").modal('show');
    //         clearInterval(intervalId);
    //         return true
            
    //     } else {
    //         console.log("Não tenho texto nos campos");

    //     }
    // }
    // intervalId = setInterval(checkInput, 1000);

    // $(".dropdown .bt-edit").click(function() {
    //     console.log("Clicou no botão");
        
    //     //clearInterval(intervalId);
    //     intervalId = setInterval(checkInput, 1000);
    // });

    // var clickHistory = [];

    // $(".bt-mobile").click(function() {
    //     // console.log("clicou no botão");
    //     clickHistory.push("Button clicked");
    //     displayHistory();
    //     // $("#modalCadastra input[type='text']").val("");
    //     // setTimeout(function(){	
    //     //     $("#modalCadastra").modal('show');
    //     // }, 1000);
        
    // });
    function alertDiplay() {
        window.onbeforeunload = function() {
            localStorage.clear();
            localStorage.removeItem("clickHistory");
          }
    }

    $("header .navbar-collapse .nav-item a").click(function() {
        alertDiplay();
    });
    $("main .container a.icon-dash").click(function() {
        alertDiplay();
    });

    var clickHistory = localStorage.getItem("clickHistory")? JSON.parse(localStorage.getItem("clickHistory")) : [];
    var modal = $("#modalCadastra");
    // localStorage.clear();

    $(".criar-bt, .dropdown .bt-edit, .dropdown-menu .dropdown-item").click(function() {
        clickHistory.push("Button clicked");
        localStorage.setItem("clickHistory", JSON.stringify(clickHistory));
        displayHistory();
    });

    function displayHistory() {
        var historyHtml = "";
        for (var i = 0; i < clickHistory.length; i++) {
        historyHtml += "<li>" + clickHistory[i] + "</li>";
        }
        $("#history").html(historyHtml);
    }

    window.onbeforeunload = function() {
        localStorage.clear();
        localStorage.removeItem("clickHistory");
        localStorage.setItem("clickHistory", JSON.stringify(clickHistory));
    }
    
    if (clickHistory.length > 0) {
        modal.modal('show');
    }

    // $("#history").val() === "" && 
    

    



    $('.mask-phone span').mask('(00) 00000-');
    $('.mask-phone span + span').text('-••••••');
    $('.mask-email span').mask('AAAA');
    $('.mask-email span + span').text('••••••@');
    $('.mask-email span + span + i').mask('AAAAAAAAAA');
    $('.mask-email span + span + i + i').text('••••••');

    $(".custom-switch input#ContentPlaceHolder1_cbPendentes").addClass("custom-control-input customSwitch");
    $(".custom-switch input#ContentPlaceHolder1_cbPendentes + label").addClass("custom-control-label");

    

    $('.filter-name').keydown(function (event) {
        if (event.key === "Space" || event.key === "Enter") {
            var input = $(this);
            var inputValue = input.val();
            //console.log(inputValue);
            if (inputValue == "") {

            }else{
                $(this).parent().next('div.result').append('<span>' + inputValue + '<i>X</i></span>');
                input.val('');
                event.preventDefault();

            }

        }

        $(this).parent().next('.result').children('span').children('i').click(function () {
            $(this).parent('span').remove();

        });
    });

    $('.navbar-toggler, .overlay-background').click(function(){
        if ($(this).hasClass('collapsed')) {
            $('body').addClass('overflow-hidden');
        }else{
            $('body').removeClass('overflow-hidden');
        }
    });

    function removeModal(){
        setTimeout(function() { 
            $('#ModalAlertCenter').modal("hide");
        }, 2000);
    }
    

    var selectInput = $('.aspNetDisabled').val();
    if (selectInput == "1") {
        $('html,body').scrollTop( $("#results").offset().top );

        setTimeout(function() { 
            $(".result-pp .PaperImpress .paper").addClass('open-result');
            $(".result-pp .PaperImpress .paper .txt-paper").addClass('open-result');
            confetti.start();
            setTimeout(function(){confetti.stop();},8000);
            removeModal();
        }, 500);
    }else{
        
    }
   
    $("#butCadastrar").click(function(e) {
        var form = $(".form-projP");
        form.validate({
            rules : {
                tbCPF:{
                    required:true,
                    minlength:14
                },
                ddlLoja:{
                    required:true
                }                          
            },
            messages:{
                tbCPF:{
                    required:"Informe seu cpf <img src='/assets/image/error.svg'>",
                    minlength:"14 caracteres <img src='/assets/image/error.svg'>"
                },
                ddlLoja:{
                    required:"Selecione uma Loja <img src='/assets/image/error.svg'>"
                }     
            },
            
            success: function(e) {
                // ADICIONAR O CÓDIGO QUANDO FINALIZAR

            }
        });
        
        
    });
    

    // Mobile 
    var isMobile = /Android|webOS|iPhone|iPod|BlackBerry/i.test(navigator.userAgent);
    if ($(window).width() < 680 || isMobile) {
        // Ajustes quantidades caracteres
        var contTXT = $('.contactor-txt');
        contTXT.text(contTXT.text().substring(0,80));

        // Visualizar senhas
        $('.eye').on('click',function(){
            if($(this).attr('data-click-state') == 1) {
                $(this).attr('data-click-state', 0);
                $(this).prev(".input-senha input").attr("type", "text");
            }else {
              $(this).attr('data-click-state', 1);
              $(this).prev(".input-senha input").attr("type", "password");
            }
        });
        $(".filter .filter-date h5, .filter .filter-order h5").next().hide();
        $(".filter .filter-date h5, .filter .filter-order h5").css('opacity','0.4');
        //$(".filter h5").next().next().hide();
        $('.filter h5').click(function(){
            $(".filter h5").css('opacity','0.4');
            $(".filter h5").next().hide();
            $(".filter h5").next().next().hide();
            $(this).css('opacity','1');
            $(this).next().toggle();
            $(this).next().next().toggle();
            
            return
        });
        // Visualizar senhas
        $('.fixed-mobile .plus-bt').siblings(".bt-mobile").hide();
        $('.fixed-mobile .plus-bt').on('click',function(){
            $(this).siblings(".bt-mobile").toggleClass("activess");
        });
        $('.fixed-mobile .bt-mobile').click(function(){
            if ($(this).siblings(".plus-bt").hasClass('activess')) {
                
                console.log("com class");
            }else{
                console.log("sem com class");
                $(this).removeClass('activess');
            }
        });
        
    }else{
        // Ajustes quantidades caracteres
        var contTXT = $('.contactor-txt');
        contTXT.text(contTXT.text().substring(0,160));

        // Visualizar senhas
        $(".eye").mousedown(function () {
            $(this).prev(".input-senha input").attr("type", "text");
        }).mouseup(function () {
            $(this).prev(".input-senha input").attr("type", "password");
        });

    }


});
// Mobile 
var isMobile = /Android|webOS|iPhone|iPod|BlackBerry/i.test(navigator.userAgent);

// Resize para Mobile
$(window).resize(function() {
    if ($(window).width() < 980 || isMobile) {
        // Ajustes quantidades caracteres
        var contTXT = $('.contactor-txt');
        contTXT.text(contTXT.text().substring(0,80));
        // alert("Mobile");
    }else{
        // Ajustes quantidades caracteres
        var contTXT = $('.contactor-txt');
        contTXT.text(contTXT.text().substring(0,160));
        // alert("Desktop");
    }
});