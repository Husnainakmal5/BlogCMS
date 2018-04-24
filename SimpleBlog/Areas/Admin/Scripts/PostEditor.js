$(document).ready(function() {
    

    $(".post-tag-editor").find(".tag-select")
        .on("click",
            ">li>a",
            function(e) {

                var $this = $(this);
                var $tagParent = $this.closest("li");
                $tagParent.toggleClass("selected");
                var selected = $tagParent.hasClass("selected");
                $tagParent.find(".selected-input").val(selected);
            });
});