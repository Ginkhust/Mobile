(function ($) {  
    function HomeIndex() {  
        var $this = this;  
  
        function initialize() {  
            $('#content').summernote({  
                focus: true,  
                height: 150,    
                codemirror: {  
                    theme: 'united'  
                }  
            });  
        }  
  
        $this.init = function () {  
            initialize();  
        }  
    }  
    $(function () {  
        var self = new HomeIndex();  
        self.init();  
    })  
}(jQuery))  