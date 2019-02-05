$(document).ready(function () {
    var html = option = "";
    $.ajax({
        url: "/AjaxOffer/ProductList",
        success: function (result) {
            res = JSON.parse(result);
            console.log((res));
            option += "<option value='' >Select  Product</option>";
            for (i = 0; i < res.length; i++) {
                option += "<option value='" + (res[i].ProductID) + "' >" + (res[i].ProductTitle) + "</option>";
            }
            
            $('#productID').html(option);
        }
    });




    $('#OfferAmount,#numberofuse').on('keydown', '#child', function (e) {
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            //display error message
            $("#errmsg").html("Digits Only").show().fadeOut("slow");
            return false;
        }
    });

    $('#OfferType').change(function () {
        type = $(this).val();
        offer = parseInt($('#OfferAmount').val());
        if (type == 1) {
            if (offer > 100) {
                $('#OfferAmount').val(0);
            }
        }
    })
    $('.OfferCode').val(makeid());
    $(".OfferAddUserID,.OfferproductID").hide();
    setTimeout(function () { $('#OfferUseType').trigger('change') }, 1000);
    $('#OfferUseType').change(function () {
        if ($(this).val() == 2) {
            $('.OfferproductID').show();
            
            
            
        } else {
            $('.OfferproductID').hide();  
            $('.OfferproductID offer').html('');   

        }
    })
})

$(function () {
    var dateFormat = "mm/dd/yy",
        from = $("#OfferStartDate")
            .datepicker({
                minDate: new Date(),
                defaultDate: "+1w",
                changeMonth: true,
                numberOfMonths: 2
            })
            .on("change", function () {
                to.datepicker("option", "minDate", getDate(this));
            }),
        to = $("#OfferEndDate").datepicker({
            minDate: new Date(),
            defaultDate: "+1w",
            changeMonth: true,
            numberOfMonths: 2
        })
            .on("change", function () {
                from.datepicker("option", "maxDate", getDate(this));
            });

    function getDate(element) {
        var date;
        try {
            date = $.datepicker.parseDate(dateFormat, element.value);
        } catch (error) {
            date = null;
        }

        return date;
    }
});

/*-------------------Random String--------------------*/
function makeid() {
    var text = "";
    var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    for (var i = 0; i < 10; i++)
        text += possible.charAt(Math.floor(Math.random() * Math.random() * Math.random() * Math.random() * possible.length));

    return text;
}

/*-------------------Random String--------------------*/