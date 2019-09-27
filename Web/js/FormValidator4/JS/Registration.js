$(document).ready(function(){
$.formValidator.initConfig({formID:"form1",onError:function(msg){alert(msg)}});
$("#iptName").formValidator().inputValidator({min:1,max:10,onError:"请填写姓名！"});
$("#iptIndenty").formValidator().inputValidator({min:1,onError:"请填写身份证号码！"}).functionValidator({fun:isCardID});
$("#iptFrom").formValidator().inputValidator({min:1,onError:"请填写籍贯！"});
$("#iptPolitics").formValidator().inputValidator({min:1,onError:"请填写政治面貌！"});
$("#iptEdu").formValidator().inputValidator({min:1,onError:"请填写教育程度！"});
$("#iptNation").formValidator().inputValidator({min:1,onError:"请填写民族！"});
$("#iptBirth").formValidator().inputValidator({min:1,onError:"请填写出生年月！"});
$("#iptTele").formValidator().inputValidator({min:1,onError:"请填写电话！"}).regexValidator({regExp:["tel","mobile"],dataType:"enum",onError:"你输入的手机或电话格式不正确"});
$("#iptEmail").formValidator().inputValidator({min:1,onError:"请填写电子邮箱！"}).regexValidator({regExp:"email",dataType:"enum",onError:"Email格式不正确！"});
$("#iptAddress").formValidator().inputValidator({min:1,onError:"请填写家庭住址！"});
})
//document.write("<script src=\"/JS/FormValidator4/JS/formValidator.js\" type=\"text/javascript\"><\/script>");
//document.write("<script src=\"/JS/FormValidator4/JS/formValidatorRegex.js\" type=\"text/javascript\"><\/script>");
//document.write("<script type=\"text/javascript\" language=\"javascript\" src=\"/JS/FormValidator4/JS/Registration.js\"><\/script>");