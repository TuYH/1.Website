/*2015-09-09 */
var lock = !1,
timeid = 0,
startPos = {
    x: 0,
    y: 0
},
endPos = {
    x: 0,
    y: 0
},
lastPos = 0,
lastTime = 0,
discover = {
    count: 0,
    maxCount: 0,
    $ul: null,
    $switchPoint: null,
    touchStart: function(a) {
        if (!lock) {
            var b = a.touches[0],
            c = Number(b.pageX),
            d = Number(b.pageY);
            startPos.x = c,
            startPos.y = d,
            clearTimeout(timeid)
        }
    },
    touchMove: function(a) {
        var b = a.touches[0],
        c = Number(b.pageX),
        d = Number(b.pageY);
        return endPos.x = c,
        endPos.y = d,
        c = endPos.x - startPos.x,
        d = endPos.y - startPos.y,
        Math.abs(c) > Math.abs(d) && (!lock && a.preventDefault() || ++lock),
        lock ? void this.doChangeImagePosition(null, 0, c + lastPos) : !1
    },
    touchEnd: function() {
        if (!lock) return ! 1;
        lock = !1,
        isover = !1;
        var a = endPos.x - startPos.x;
        lastPos += a,
        Math.abs(a) > 80 ? this.doChange(a > 0 ? this.count--:this.count++) : this.doChange()
    },
    touchCancel: function() {
        lock = !1,
        isover = !1,
        this.AutoPlay()
    },
    doChangeImagePosition: function(a, b, c) {
        var d = {};
        a = a || this.$ul,
        void 0 !== c && (d["-webkit-transform"] = "translate3D(" + c + "px, 0px, 0px)", d.transform = "translate3D(" + c + "px, 0px,0px)"),
        b >= 0 && lastTime != b && (d["-webkit-transition"] = b + "ms", d.transition = b + "ms", lastTime = b),
        this.reflush && (d["-webkit-transition"] = "0ms", d.transition = "0ms"),
        a.css(d)
    },
    doChange: function() {
        var a = this,
        b = $(".banner").width();
        a.count < 0 ? this.count = 0 : a.count > this.maxCount && (a.count = a.maxCount),
        lastPos = -b * a.count,
        a.doChangeImagePosition(null, b, lastPos),
        a.doChangeImagePosition(a.$switchPoint, 0, 14 * a.count),
        a.doChangeImagePosition(null, b),
        a.AutoPlay()
    },
    imgCount: 0,
    doInitFocusImg: function() {
        var a, b = this,
        c = "",
        d = [],
        e = 0,
        f = 0,
        g = "",
        h = $(".banner").width(),
        i = $(".banner-wrapper"),
        j = 0,
        k = $(".banner-switch"),
        l = JSON.parse(i.attr("data-focus-images"));
        b.$ul = i,
        b.$switchPoint = k.find("a"),
        j = l.length,
        b.imgCount = j;
        for (var m in l) {
            switch (m = l[m], c = m.type, e++, c) {
	            case 7:
	            case 6:
	            case 5:
	                a = "/" + m.id;
	                break;
	            case 4:
	                a = m.url;
	                break;
	            case 8:
	                a = m.url.replace(/\?(.*)/, "");
	                break;
	            case 3:
	                a = m.uid ;
	                break;
	            case 2:
	                a = "/" + m.uid + "/album/" + m.album_id;
	                break;
	            case 1:
	                a = "/" + m.uid
            }
            g = '<li class="pic"><a data-category="广告点击" data-role="ga" data-event="event" data-tag="首页广告" data-done="焦点图' + e + '" href="' + a + '"><img  src="' + (m.pic ? m.pic: "") + '" alt="" style="width:' + h + 'px;"></a></li>  ',
            d.push(g);
            var n = new Image;
            n.onload = function() {
                f++,
                f == j && b.initFocusImgTouch(i, k, d, j)
            },
            n.onerror = function() {
                f++,
                f == j && b.initFocusImgTouch(i, k, d, j)
            },
            m.pic ? n.src = m.pic: f++
        }
    },
    initFocusImgTouch: function(a, b, c, d) {
        var e = this,
        f = $(".banner").width();
        c && a.empty().append(c.join("")),
        a.size() && (ul = a[0], e.reflush || (ul.addEventListener("touchstart",
        function(a) {
            e.touchStart(a)
        },
        !1), ul.addEventListener("touchmove", function(a) {
            e.touchMove(a)
        },
        !1), ul.addEventListener("touchend", function(a) {
            e.touchEnd(a)
        },
        !1), ul.addEventListener("touchcancel", e.touchCancel, !1)), a.width(f * d), b.width(13 * d), e.maxCount = --d)
    },
    doInitCateImgs: function() {
        $(".category .cateBtn img").each(function() {
            var a = $(this),
            b = new Image;
            b.onload = function() {
                a.attr("src", a.attr("url")).show()
            },
            b.src = a.attr("url")
        })
    },
    reflush: !1,
    renderBanner: function() {
        var a = this;
        clearTimeout(timeid),
        a.reflush = !0;
        var b = $(".banner").width(),
        c = $(".banner-wrapper");
        $(".banner-wrapper .pic img").css("width", b),
        c.width(b * a.imgCount),
        a.count < 0 ? this.count = 0 : a.count > this.maxCount && (a.count = a.maxCount),
        lastPos = -b * a.count,
        a.doChangeImagePosition(null, b, -b * a.count),
        a.doChangeImagePosition(a.$switchPoint, 0, 14 * a.count),
        a.doChangeImagePosition(null, b),
        a.AutoPlay()
    },
    Init: function() {
        var a = this;        
        this.BindEvent(), 
        this.doInitCateImgs(), 
        this.doInitFocusImg(), 
        a.renderBanner(), 
        $(window).resize(function() {
            a.renderBanner()
        });
        var c = $("img[data-original]");
        c.lazyload({
            placeholder: null,
            effect: "fadeIn",
            event: "scroll",
            specialEvent: "scroll"
        }),
        FastClick.attach(document.body)
    },
    BindEvent: function() {
        $(".category2");
        $(".item.rel").on("click",
        function() {
            $(".item.rel a img").toggleClass("hidden"),
            $(".more-cont").toggleClass("hidden")
        }),
        $(".btn-search").on("click",
        function() {
            DisSearch && DisSearch.init()
        }),
        $("[data-url]").on("click",
        function() {
            var a = $(this).attr("data-url");
            a && (location.href = a)
        }),
        $(".discoverModuleSound .sound").on("click",
        function() {
            var a = $(this).attr("data-uid"),
            b = $(this).attr("data-track-id");
            a && b && (location.href = "/" + a + "/sound/" + b)
        })
    },
    AutoPlay: function() {
        var a = this;
        a.reflush = !1,
        timeid = setTimeout(function() {
            a.count++,
            a.count > a.maxCount && (a.count = 0),
            a.doChange()
        },
        3e3)
    }
};
$(function() {
    discover.Init()
});