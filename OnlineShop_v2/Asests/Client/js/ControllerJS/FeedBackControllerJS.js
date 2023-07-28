var Feedback = {
    init: () => {
        Feedback.resEvent();
    },
    resEvent: () => {
        $('#SendFeedbackBtn').off('click').on('click', function () {
            var feedbackerName = $('#txtYourName').val()
            var feedbackerEmail = $('#txtYourEmail').val()
            var feedbackerContent = $('#txtYourContent').val()
            var feedbackerPhone = $('#txtYourPhone').val();
            var feedbackerAddress = $('#txtYourAddress').val();

            $.ajax({
                url: '/Contact/SendFeedBack',
                dataType: 'json',
                data: {
                    feedbackerName: feedbackerName,
                    feedbackerEmail: feedbackerEmail,
                    feedbackerContent: feedbackerContent,
                    feedbackerPhone: feedbackerPhone,
                    feedbackerAddress: feedbackerAddress,
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert("Gửi phản hồi thành công.")
                    }
                    else {
                        window.alert("Gửi phản hồi thất bại.")

                    }
                }
            })
        })
    }
}

Feedback.init();