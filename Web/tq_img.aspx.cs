﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;

public partial class tq_img : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str_news = "";
        string OriginalStr = HXD.DBUtility.SQLHelper.ExecuteScalar("select Content from tb_U_info where id=2").ToString();
        //string OriginalStr ="<p>人的一生会经历各个不同的阶段，每个阶段有着不同的身心发展的任务。如果在当下的阶段很好的完成了这一发展任务，那么在之后的人生过程中将更为顺利。下面灵心心理<a href="http://www.hnxlzx.cn">心理咨询</a>师带你说说孩子的0-18岁都会有什么心理变化</p>  <p>0&mdash;6岁称为学龄前,也称为最佳发展期即大脑发育的关键期，到6岁大脑发育基本成熟。<br />  &nbsp;&nbsp;&nbsp;  研究发现许多优秀人才和所谓的&ldquo;天才&ldquo;都是抓住了0-6岁的最佳发展期将其潜能开发出来的，所以每个孩子都有巨大潜能，关键是要抓住最佳发展期。在这个时期孩子的左脑（理性脑、记忆脑）发育较慢，右脑（图形脑、创造脑）发育较快，因此在这个时期，很多家长送孩子参加绘画、舞蹈等业余班是非常好的选择，因为在最佳期深度开发孩子的大脑，那孩子未来就有可能成为天才人物。先是0-6岁要经理的心理变化。</p>  <p><img src="http://www.hnxlzx.cn/d/file/news/campus/2017-07-04/cab2e3aeb917eff09f6c2bea1d1999cf.jpg" alt="01.jpg" height="454" width="600" /><br />  0&mdash;18个月：建立基本信任感<br />  <br />  每个人还在婴儿期的时候，对外界需要高度的依赖，但是外界的环境是否值得婴儿依赖与信任就是这个时期很重要的事情。倘若在婴儿期，你可以获得很好的母亲或者家人的照顾，照顾者能够很好的养育你，知饥饱，知冷热，你会感觉这个世界是充满了信任与关怀的。<br />  <br />  18个月&mdash;3、4岁：建立自主感和避免羞耻感<br />  <br />  大部分的小孩在在这个阶段开始学习走路、说话、吃饭、穿衣、拿玩具，小孩萌发出非常强大的学习能力和好奇心。他们会开始拒绝父母的勺子，开始自己动手用勺子哪怕根本舀不到任何东西；他们开始挡开父母的手要努力向前走。<br />  <br />  这是个体习得自主感的重要阶段，但往往有的父母在这个阶段的过渡保护和包办会让孩子失去建立自主感的机会，也会让孩子体会到失败和受挫的羞耻感，这很可能影响到孩子今后是否有面临挑战的勇气和决心。<br />  <img src="http://www.hnxlzx.cn/d/file/news/campus/2017-07-04/2d288e208e8d5a2a0c52f5d91585b3ee.jpg" alt="02.jpg" height="456" width="491" /><br />  4&mdash;5岁：面临一种内疚感<br />  <br />  当他们面对父母的否定和压制的时候，他们会感到被父母拒绝和讨厌而很挫败和内疚。在过于严苛的家庭里面，孩子往往会生活在强烈的内疚之中，认为自己要做到很好才可以对得起父母。这样强烈的内疚感是会影响今后的发展生活的。<br />  <br />  父母在这一时期需注意如下问题：<br />  1、父母和孩子的对话大于对立，要多和孩子进行有启发性的对话，不要和孩子讲过多的道理，否则孩子会过早的陷入沉思，未来性格会比较内向。<br />  2、在这个时期孩子已经可以独立做很多的事，父母不要去替代，中国的父母有时候恨不得把孩子的一生都能够包起来，让孩子做一些力所能及的事情，一方面是培养孩子做事的能力，另一方面也是培养孩子责任心及训练思维能力的重要机会。总之父母在孩子面前要学会示弱，给孩子一点回报爱的机会，父母不要总是把自己看成是一座高山，当孩子是小草，让孩子永远靠着你；父母也不要总是把自己看成是大伞，当孩子是小鸡，你永远可以为他遮风挡雨；父母不妨换一种做法，让你来做小草，孩子未来才可能发展为高山；让你来做小鸡，孩子未来才有可能变成一把大伞，所以父母如果真的爱孩子，就放手让他去做事情，给他锻炼成长的机会，不要剥夺他做事的权利。<br />  <br />  <img src="http://www.hnxlzx.cn/d/file/news/campus/2017-07-04/5d3d59a5f9e28c411fa0c7468acfe40e.jpg" alt="04.jpg" height="399" width="600" /><br />  6&mdash;12岁： 获得勤奋感，避免自卑感<br />  <br />  个体在这个阶段进入了学习期，在学习过程中体验自己的努力和勤奋与积极的结果的关系；然而也有的个体在这个过程中很受挫败，如果父母总是以否定和消极的方式看待孩子，会让孩子感到异常的自卑，进而没办法形成和取得个人的成就感。<br />  <br />  <br />  6-12岁是暗示教育特别重要的阶段，是给孩子种信念、种心结的重要时期，也是需要老师和家长协调好的重要时期。<br />  父母在这一时期需注意如下问题：<br />  1、在这个阶段孩子慢慢的长大，父母不再象6岁以前经常亲吻、拥抱、触摸孩子，也就是说父母和孩子亲密接触程度减少了，父母忽略了这个细节孩子就可能情感上被冷落，所以忽略了这个细节就有可能忽略了孩子的情感需求，所以随着孩子年龄的增长父母要学会用其他方式不断向孩子表达你对他的爱，这样孩子的情感才不会有缺失。<br />  2、这个阶段孩子进入了学习比较重要的阶段，因此在这个期间父母总喜欢一味的向孩子要成绩、要高的分数，孩子表现好，父母开心，孩子表现不好，父母满脸乌云密布，其实父母一定要把对孩子的爱和具体的事情分开，父母应让孩子明白你对他们的爱是无条件的，不要让孩子总觉得对他的爱是因为他取得好的分数，你的爱总是有条件的，也许孩子成长中会犯很多的错误，但一定要告诉孩子：&ldquo;虽然你因犯错误受到父母的批评，但父母对你爱永远不会改变。&rdquo;因为父母要明白犯错误是孩子在成长过程中的必然现象，所有的孩子都是在错误中成长的。<br />  3、此阶段也是给孩子种信念、种心结的重要时期，父母不要总以自己的观点认为孩子还小，所以随便放纵自己的言语和行为，殊不知，你无意间的言行可能已经伤害到了孩子，无数次的积累，虽然暂时没有爆发，但秋后就会算总账，孩子心灵积累的伤害在某个时期或成年后由于外在的刺激就可能随时引爆。所以父母在这个阶段要学会保护孩子纯真的情怀，对他们的问题及变化给予积极的回应，父母如果给孩子种下很多不好的心结与信念，那就很难奢望孩子未来发展成一个性格健全、情绪稳定的人。<br />  <br />  <img src="http://www.hnxlzx.cn/d/file/news/campus/2017-07-04/c7e40325e5a4baba9786c8cce93a62a9.jpg" alt="05.jpg" height="400" width="600" /><br />  12&mdash;18岁：青春期自我意识爆发<br />  青春期的孩子有时候会做点离经叛道的事情，这并不是因为他们本性很坏，而只是希望有机会去表现&ldquo;真正的自我&rdquo;。他们通过疏远父母，不与父母交流，不听父母的教诲，找到合群的同伴，有自己的小团体等方式来彰显自己个体的存在感，他们要向这个世界发出声音，告诉世界我是谁，他们不希望自己只是家庭的附属品，而是希望有机会被人看到自我的存在。<br />  <br />  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  由于这个期间的发展是非常复杂的，又称为&ldquo;困难期&rdquo;、&ldquo;危机期&rdquo;与&ldquo;大动荡&rdquo;阶段。这个时期孩子生理上的变化会引起心理上的变化，心理上的变化进一步会引起行为上的变化，这个时期是孩子思想、观念有很大的冲突，处于极其矛盾的状态，孩子的价值观正在形成，所以孩子的做人就掌握在父母的手中，和谐良好的家庭氛围与环境变得尤为重要，养鱼还要先养水，所有的孩子都是环境的孩子。</p>  <p>&nbsp;</p>"
        //把源字符串中“，替换成\"，\替换成\\
        OriginalStr = OriginalStr.Replace("\"", "\"");
        //OriginalStr = OriginalStr.Replace("/", "\\");
        StringBuilder mySB = new StringBuilder();
        int CurrenEnd;
        int StartPont = OriginalStr.IndexOf("src=\"");
        for (int i = StartPont; i < OriginalStr.Length && i > 0; i = OriginalStr.IndexOf("src=\"", CurrenEnd + 1))
        {
            CurrenEnd = OriginalStr.IndexOf("\"", i + 5);
            str_news +=  OriginalStr.Substring(i, CurrenEnd - i + 1);
        }


    




        Response.Write(str_news);


      
    }
}