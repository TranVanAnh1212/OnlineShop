var user = {
    init: function () {
        user.registerEvents()
    },

    registerEvents: function () {
        $(".btn-active").off("click").on("click", function (e) {
            e.preventDefault()

            const btn = $(this)

            $.ajax({
                url: "/Admin/User/ChangedStatus",
                data: { id: btn.data("id") },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    if (response.status == true) {
                        btn.text('Kích hoạt')
                    }
                    else {
                        btn.text('Khóa')
                    }
                }
            })
        })
    }
}

user.init()