      $(function () {
          $("#fileupload").change(function () {
              $("#dvPreview").html("");
              var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.jpg|.jpeg|.gif|.png|.bmp)$/;
              if (regex.test($(this).val().toLowerCase())) {
                  if (getInternetExplorerVersion()>-1) {
                      $("#dvPreview").show();
                      $("#dvPreview")[0].filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = $(this).val();
                  }
                  else {
                      if (typeof (FileReader) != "undefined") {
                          $("#dvPreview").show();
                          $("#dvPreview").append("<img />");
                          var reader = new FileReader();
                          reader.onload = function (e) {
                              $("#dvPreview img").attr("src", e.target.result);
                              $("#dvPreview img").attr("id", "imgDisplay");
                          }
                          reader.readAsDataURL($(this)[0].files[0]);
                      } else {
                          alert("This browser does not support FileReader.");
                      }
                  }
              } else {
                  alert("Please upload a valid image file.");
              }
          });
      });
/**
//* Returns the version of Internet Explorer or a -1
//* (indicating the use of another browser).
//*/
function getInternetExplorerVersion() {
    var rv = -1; // Return value assumes failure.

    if (navigator.appName == 'Microsoft Internet Explorer') {
        var ua = navigator.userAgent;
        var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
        if (re.exec(ua) != null)
            rv = parseFloat(RegExp.$1);
    }

    return rv;
}

//       function checkVersion() {
//           var msg = "You're not using Internet Explorer.";
//           var ver = getInternetExplorerVersion();

//           if (ver > -1) {
//               if (ver >= 8.0)
//                   msg = "You're using a recent copy of Internet Explorer."
//               else
//                   msg = "You should upgrade your copy of Internet Explorer.";
//           }

//           alert(msg);
//       }
