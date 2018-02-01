

var nthTabs;
var userbackstageindex = {
    menuclick: function (urldata) {
        var urlhash = [];
        urlhash.push({
            data: 'main',
            url:'',
        });
        urlhash.push({
            data: 'aritclemanage',
            url: '',
        });
        urlhash.push({
            data: 'aritclemanage-all',
            url: '',
        });
        urlhash.push({
            data: 'aritclemanage-publish',
            url: '',
        });
        urlhash.push({
            data: 'aritclemanage-drafts',
            url: '',
        });
        urlhash.push({
            data: 'aritclemanage-deleted',
            url: '',
        });
        urlhash.push({
            data: 'comment',
            url: '',
        });
        urlhash.push({
            data: 'comment-myarticle',
            url: '',
        });
        urlhash.push({
            data: 'comment-ipublished',
            url: '',
        });
        urlhash.push({
            data: 'articleclass',
            url: '',
        });
        urlhash.push({
            data: 'articleclass-type',
            url: '',
        });
        urlhash.push({
            data: 'articleclass-label',
            url: '',
        });
        urlhash.push({
            data: 'blogsetup',
            url: '',
        });

      
        var tablist = nthTabs.getTabList();
        var id = '#' + urldata;
        var exist = false;
        $.each(nthTabs.getTabList(), function () {
            if (this.id === id) {
                exist = true;
                return false;
            }
        });
        if (exist) {
            //如果tab已经存在
            nthTabs.setActTab(id);
        }
        else {
            //如果tab不存在


        }
        $('iframe').css('margin-top', '35px');
    },
};
$(function () {
    //一个低门槛的演示,更多需求看源码
    //基于bootstrap tab的自定义多标签的jquery实用插件，滚动条依赖jquery.scrollbar，图标依赖font-awesome
    nthTabs = $("#editor-tabs").nthTabs();
    //添加主页

    nthTabs.addTab({
        /*换个姿势*/
        id: 'b',
        title: '猪八戒-关不掉',
        content: '高老庄娶媳妇高老庄娶媳妇高老<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>12123123132',

    }).addTab({
        id: 'blogsetup',
        title: '编辑文章',
        content: '<iframe src="/UserBackStage/Editor" frameborder="0" scrolling="no"  width="100%" ></iframe>',//'<iframe id="testIframe1"  src="/UserBackStage/Editor" frameborder="0"   scrolling="auto" style="display:blodk; width:100%; "></iframe>',//'<iframe src="/UserBackStage/UserInfo"></iframe>',,
    }).addTab({
        id: 'e',
        title: '武松',
        content: '<iframe frameborder="0"  src="http://www.baidu.com"></iframe>',
    });

    $('.sidebar-nav li>a[urldata]').click(function () {
        var urldata = $(this).attr('urldata');
        userbackstageindex.menuclick(urldata);
    });

    $('.nth-tabs>.page-tabs').css('position', 'fixed');
    $('.nth-tabs>.page-tabs').css('margin-top', '-2px');
    $('iframe').css('margin-top','35px');
});

//jQuery(function () {
//    $('iframe').iframeAutoHeight({
//        debug: true,
//        minHeight: 500,
//        diagnostics: true
//    });
//});
jQuery(function ($) {
    $('iframe').iFrameResize();
})