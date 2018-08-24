
    $(document).ready(function () {
        $("input[name$='sortOrder']").click(function () {
            var parametr = $(this).val();
            $("div.desc").hide();
            $("#sortby" + parametr).show();
        });
    });


