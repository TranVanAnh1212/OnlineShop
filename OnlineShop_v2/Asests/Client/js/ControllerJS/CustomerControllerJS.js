var customer = {
    init: function () {
        customer.regEvent();
    },
    regEvent: function () {
        $('#showPassCkb').on('click', function () {
            if ($(this).prop('checked')) {
                $('#InputPassword').attr('type', 'text')
                $('#RepeatPassword').attr('type', 'text')
            }
            else {
                $('#InputPassword').attr('type', 'password')
                $('#RepeatPassword').attr('type', 'password')

            }
        })

        $('#loginCkb').on('click', function () {
            if ($(this).prop('checked')) {
                $('#InputPassword').attr('type', 'text')
            }
            else {
                $('#InputPassword').attr('type', 'password')
            }
        })
    }
}

customer.init()