(function ($) {
    function Home() {
        var $this = this;

        function initialize() {
            $('#thumbnailImage').summernote({
                airPopover: [
                    ['insert', ['picture']]
                ]
            });
            $('#img .note-toolbar .note-style,#img .note-toolbar .note-font, #img .note-toolbar .note-fontsize,#img .note-toolbar .note-para,#img .note-toolbar .note-height,#img .note-toolbar .note-table,#img .note-toolbar .note-view,#img .note-toolbar .note-help, #img .note-toolbar .note-color, #img .note-toolbar .note-fontname, #img .note-toolbar .note-insert button[data-event="insertHorizontalRule"]').remove();
        }

        $this.init = function () {
            initialize();
        }
    }
    $(function () {
        var self = new Home();
        self.init();
    })
}(jQuery))