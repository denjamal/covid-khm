
jQuery(document).ready(function () {
    $('#form').submit(function () {
        if (document.form.PersonName == '' || document.form.Phone == '' || document.form.type.value=="type_0") {
            valid = false;
            return valid;
        }
        $.ajax({
            type: "POST",
            url: __url,
            data: $(this).serialize()
        }).done(function () {
            $(this).find('input').val('');
            $('#form').trigger('reset');
        });
        return false;
    });
});

let __url;

function TypeChange() {
    if (document.getElementById('type').value == "type_2") {
        // document.getElementById('form1').action = "/umbraco/api/signup/createVolunteer";
        __url = "/umbraco/api/signup/createVolunteer";
        document.getElementById('email').style.display = "none";
        document.getElementById('address').style.display = "block";
        document.getElementById('age').style.display = "block";
        document.getElementById('description').placeHolder = "Description";
    }
    else if (document.getElementById('type').value == "type_3") {
        // document.getElementById('form1').action = "/umbraco/api/signup/createSupplier";
        __url = "/umbraco/api/signup/createSupplier";
        document.getElementById('email').style.display = "block";
        document.getElementById('address').style.display = "none";
        document.getElementById('age').style.display = "none";
        document.getElementById('description').placeHolder = "Description";
    }
    else if (document.getElementById('type').value == "type_4") {
        //document.getElementById('form1').action = "/umbraco/api/signup/createBenefactor";
        __url = "/umbraco/api/signup/createBenefactor";
        document.getElementById('email').style.display = "block";
        document.getElementById('address').style.display = "none";
        document.getElementById('age').style.display = "none";
        document.getElementById('description').placeHolder = "Description";
    }
    else if (document.getElementById('type').value == "type_1") {
        // document.getElementById('form1').action = "/umbraco/api/signup/CreateExtraDoctor";
        __url = "/umbraco/api/signup/CreateExtraDoctor";
        document.getElementById('email').style.display = "none";
        document.getElementById('address').style.display = "block";
        document.getElementById('age').style.display = "block";
        document.getElementById('description').placeHolder = "Medical specialization";
    }
    else if (document.getElementById('type').value == "type_0") {
        document.getElementById('email').style.display = "block";
        document.getElementById('address').style.display = "block";
        document.getElementById('age').style.display = "block";
        document.getElementById('description').placeHolder = "Description";
    }
}