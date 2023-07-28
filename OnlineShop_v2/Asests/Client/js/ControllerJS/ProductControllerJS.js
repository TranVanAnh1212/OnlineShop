var product = {
    init: function () {
        product.regEvent()
    },
    regEvent: function () {
        $("#txtSearchProduct").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/ClientProduct/ListNameProduct",
                    dataType: "json",
                    data: {
                        term: request.term
                    },
                    success: function (data) {
                        response(data.result);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtSearchProduct").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtSearchProduct").val(ui.item.label);
                return false;
            }
        })
        .autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append("<a>" + item.label + "</a>")
                .appendTo(ul);
        };
    }
}
product.init()