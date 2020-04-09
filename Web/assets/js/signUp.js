
var url;
var requiredFieldMsg = "Це поле обов'язкове";

jQuery(document).ready(function () {
    var form$ = $("#form");

    form$.validate({
        rules: {
            personName: "required",
            phone: "required",
            category: 'required'
        },
        messages: {
            personName: {
                required: requiredFieldMsg
            },
            phone: {
                required: requiredFieldMsg
            },
            category: {
                required: requiredFieldMsg
            }
        },
        submitHandler: function () {
            $.ajax({
                type: "POST",
                url: url,
                data: form$.serialize()
            }).done(function () {
                alert("Заявка успішно надіслана");
                form$.trigger('reset');
            });
        }
    });
});


function formTypeChanged() {
    if (document.getElementById('type').value === "type_2") {
        url = "/umbraco/api/signup/createVolunteer";
        $('#email').hide();
        $('#address').show();
        $('#age').show();
    }
    else if (document.getElementById('type').value === "type_3") {
        url = "/umbraco/api/signup/createSupplier";
        $('#email').show();
        $('#address').hide();
        $('#age').hide();
    }
    else if (document.getElementById('type').value === "type_4") {
        url = "/umbraco/api/signup/createBenefactor";
        $('#email').show();
        $('#address').hide();
        $('#age').hide();
    }
    else if (document.getElementById('type').value === "type_1") {
        url = "/umbraco/api/signup/CreateExtraDoctor";
        $('#email').hide();
        $('#address').show();
        $('#age').show();
    }
}