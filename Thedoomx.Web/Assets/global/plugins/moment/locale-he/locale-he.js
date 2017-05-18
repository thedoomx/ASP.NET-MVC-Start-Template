             $(".signedOn").each(function () {
                var d = moment($(this).attr("data-raw-date")).fromNow();
                if (d != "Invalid date") {
                    $(this).html(d);
                }
            });

            $(".viewedOn").each(function () {
                var d = moment($(this).attr("data-raw-date")).fromNow();
                if (d != "Invalid date") {
                    $(this).html(d);
                }
            });

            $(".sentOn").each(function () {
                var d = moment($(this).attr("data-raw-date")).fromNow();
                if (d != "Invalid date") {
                    $(this).prepend(d);
                }
            });

            $(".createdOn").each(function () {
                var d = moment($(this).attr("data-raw-date")).fromNow();
                if (d != "Invalid date") {
                    $(this).html(d);
                }
            });