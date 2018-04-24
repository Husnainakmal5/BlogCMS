$(document).ready(function () {
    $("a[data-post]").click(function (e) {
        e.PreventDefault();
        var $this = $(this);
        var massage = $this.data("post");

        if (massage && !confirm(massage))
            return;

        $("<form>")
        .attr("method", "post")
        .attr("action", $this.attr("href"))
        .appendTo(document.body)
        .submit();
    });

    $("#Title").keyup(function() {


        var slug = $("#Title").val();

       
           
            slug = slug.replace(/[^a-zA-Z0-9\s]/g, "");
            slug = slug.toLowerCase();
            slug = slug.replace(/\s+/g, "-");

            if (slug.charAt(slug.length - 1) === "-")
                slug = slug.substr(0, slug.length - 1);

        $("#Slug").val(slug);


    });

});