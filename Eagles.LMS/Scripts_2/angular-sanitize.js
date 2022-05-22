﻿/*
 AngularJS v1.7.8
 (c) 2010-2018 Google, Inc. http://angularjs.org
 License: MIT
*/
(function (s, c) {
    'use strict'; function P(c) { var h = []; C(h, E).chars(c); return h.join("") } var D = c.$$minErr("$sanitize"), F, h, G, H, I, q, E, J, K, C; c.module("ngSanitize", []).provider("$sanitize", function () {
        function f(a, e) { return B(a.split(","), e) } function B(a, e) { var d = {}, b; for (b = 0; b < a.length; b++) d[e ? q(a[b]) : a[b]] = !0; return d } function t(a, e) { e && e.length && h(a, B(e)) } function Q(a) { for (var e = {}, d = 0, b = a.length; d < b; d++) { var k = a[d]; e[k.name] = k.value } return e } function L(a) {
            return a.replace(/&/g, "&amp;").replace(z, function (a) {
                var d =
                a.charCodeAt(0); a = a.charCodeAt(1); return "&#" + (1024 * (d - 55296) + (a - 56320) + 65536) + ";"
            }).replace(u, function (a) { return "&#" + a.charCodeAt(0) + ";" }).replace(/</g, "&lt;").replace(/>/g, "&gt;")
        } function A(a) { for (; a;) { if (a.nodeType === s.Node.ELEMENT_NODE) for (var e = a.attributes, d = 0, b = e.length; d < b; d++) { var k = e[d], g = k.name.toLowerCase(); if ("xmlns:ns1" === g || 0 === g.lastIndexOf("ns1:", 0)) a.removeAttributeNode(k), d--, b-- } (e = a.firstChild) && A(e); a = v("nextSibling", a) } } function v(a, e) {
            var d = e[a]; if (d && J.call(e, d)) throw D("elclob",
            e.outerHTML || e.outerText); return d
        } var y = !1, g = !1; this.$get = ["$$sanitizeUri", function (a) { y = !0; g && h(m, l); return function (e) { var d = []; K(e, C(d, function (b, d) { return !/^unsafe:/.test(a(b, d)) })); return d.join("") } }]; this.enableSvg = function (a) { return I(a) ? (g = a, this) : g }; this.addValidElements = function (a) { y || (H(a) && (a = { htmlElements: a }), t(l, a.svgElements), t(r, a.htmlVoidElements), t(m, a.htmlVoidElements), t(m, a.htmlElements)); return this }; this.addValidAttrs = function (a) { y || h(M, B(a, !0)); return this }; F = c.bind; h = c.extend;
        G = c.forEach; H = c.isArray; I = c.isDefined; q = c.$$lowercase; E = c.noop; K = function (a, e) {
            null === a || void 0 === a ? a = "" : "string" !== typeof a && (a = "" + a); var d = N(a); if (!d) return ""; var b = 5; do { if (0 === b) throw D("uinput"); b--; a = d.innerHTML; d = N(a) } while (a !== d.innerHTML); for (b = d.firstChild; b;) {
                switch (b.nodeType) { case 1: e.start(b.nodeName.toLowerCase(), Q(b.attributes)); break; case 3: e.chars(b.textContent) } var k; if (!(k = b.firstChild) && (1 === b.nodeType && e.end(b.nodeName.toLowerCase()), k = v("nextSibling", b), !k)) for (; null == k;) {
                    b =
                    v("parentNode", b); if (b === d) break; k = v("nextSibling", b); 1 === b.nodeType && e.end(b.nodeName.toLowerCase())
                } b = k
            } for (; b = d.firstChild;) d.removeChild(b)
        }; C = function (a, e) {
            var d = !1, b = F(a, a.push); return {
                start: function (a, g) { a = q(a); !d && w[a] && (d = a); d || !0 !== m[a] || (b("<"), b(a), G(g, function (d, g) { var c = q(g), f = "img" === a && "src" === c || "background" === c; !0 !== M[c] || !0 === O[c] && !e(d, f) || (b(" "), b(g), b('="'), b(L(d)), b('"')) }), b(">")) }, end: function (a) { a = q(a); d || !0 !== m[a] || !0 === r[a] || (b("</"), b(a), b(">")); a == d && (d = !1) }, chars: function (a) {
                    d ||
                    b(L(a))
                }
            }
        }; J = s.Node.prototype.contains || function (a) { return !!(this.compareDocumentPosition(a) & 16) }; var z = /[\uD800-\uDBFF][\uDC00-\uDFFF]/g, u = /([^#-~ |!])/g, r = f("area,br,col,hr,img,wbr"), x = f("colgroup,dd,dt,li,p,tbody,td,tfoot,th,thead,tr"), p = f("rp,rt"), n = h({}, p, x), x = h({}, x, f("address,article,aside,blockquote,caption,center,del,dir,div,dl,figure,figcaption,footer,h1,h2,h3,h4,h5,h6,header,hgroup,hr,ins,map,menu,nav,ol,pre,section,table,ul")), p = h({}, p, f("a,abbr,acronym,b,bdi,bdo,big,br,cite,code,del,dfn,em,font,i,img,ins,kbd,label,map,mark,q,ruby,rp,rt,s,samp,small,span,strike,strong,sub,sup,time,tt,u,var")),
        l = f("circle,defs,desc,ellipse,font-face,font-face-name,font-face-src,g,glyph,hkern,image,linearGradient,line,marker,metadata,missing-glyph,mpath,path,polygon,polyline,radialGradient,rect,stop,svg,switch,text,title,tspan"), w = f("script,style"), m = h({}, r, x, p, n), O = f("background,cite,href,longdesc,src,xlink:href,xml:base"), n = f("abbr,align,alt,axis,bgcolor,border,cellpadding,cellspacing,class,clear,color,cols,colspan,compact,coords,dir,face,headers,height,hreflang,hspace,ismap,lang,language,nohref,nowrap,rel,rev,rows,rowspan,rules,scope,scrolling,shape,size,span,start,summary,tabindex,target,title,type,valign,value,vspace,width"),
        p = f("accent-height,accumulate,additive,alphabetic,arabic-form,ascent,baseProfile,bbox,begin,by,calcMode,cap-height,class,color,color-rendering,content,cx,cy,d,dx,dy,descent,display,dur,end,fill,fill-rule,font-family,font-size,font-stretch,font-style,font-variant,font-weight,from,fx,fy,g1,g2,glyph-name,gradientUnits,hanging,height,horiz-adv-x,horiz-origin-x,ideographic,k,keyPoints,keySplines,keyTimes,lang,marker-end,marker-mid,marker-start,markerHeight,markerUnits,markerWidth,mathematical,max,min,offset,opacity,orient,origin,overline-position,overline-thickness,panose-1,path,pathLength,points,preserveAspectRatio,r,refX,refY,repeatCount,repeatDur,requiredExtensions,requiredFeatures,restart,rotate,rx,ry,slope,stemh,stemv,stop-color,stop-opacity,strikethrough-position,strikethrough-thickness,stroke,stroke-dasharray,stroke-dashoffset,stroke-linecap,stroke-linejoin,stroke-miterlimit,stroke-opacity,stroke-width,systemLanguage,target,text-anchor,to,transform,type,u1,u2,underline-position,underline-thickness,unicode,unicode-range,units-per-em,values,version,viewBox,visibility,width,widths,x,x-height,x1,x2,xlink:actuate,xlink:arcrole,xlink:role,xlink:show,xlink:title,xlink:type,xml:base,xml:lang,xml:space,xmlns,xmlns:xlink,y,y1,y2,zoomAndPan",
        !0), M = h({}, O, p, n), N = function (a, e) {
            function d(b) { b = "<remove></remove>" + b; try { var d = (new a.DOMParser).parseFromString(b, "text/html").body; d.firstChild.remove(); return d } catch (e) { } } function b(a) { c.innerHTML = a; e.documentMode && A(c); return c } var g; if (e && e.implementation) g = e.implementation.createHTMLDocument("inert"); else throw D("noinert"); var c = (g.documentElement || g.getDocumentElement()).querySelector("body"); c.innerHTML = '<svg><g onload="this.parentNode.remove()"></g></svg>'; return c.querySelector("svg") ?
            (c.innerHTML = '<svg><p><style><img src="</style><img src=x onerror=alert(1)//">', c.querySelector("svg img") ? d : b) : function (b) { b = "<remove></remove>" + b; try { b = encodeURI(b) } catch (d) { return } var e = new a.XMLHttpRequest; e.responseType = "document"; e.open("GET", "data:text/html;charset=utf-8," + b, !1); e.send(null); b = e.response.body; b.firstChild.remove(); return b }
        }(s, s.document)
    }).info({ angularVersion: "1.7.8" }); c.module("ngSanitize").filter("linky", ["$sanitize", function (f) {
        var h = /((s?ftp|https?):\/\/|(www\.)|(mailto:)?[A-Za-z0-9._%+-]+@)\S*[^\s.;,(){}<>"\u201d\u2019]/i,
        t = /^mailto:/i, q = c.$$minErr("linky"), s = c.isDefined, A = c.isFunction, v = c.isObject, y = c.isString; return function (c, z, u) {
            function r(c) { c && l.push(P(c)) } function x(c, g) { var f, a = p(c); l.push("<a "); for (f in a) l.push(f + '="' + a[f] + '" '); !s(z) || "target" in a || l.push('target="', z, '" '); l.push('href="', c.replace(/"/g, "&quot;"), '">'); r(g); l.push("</a>") } if (null == c || "" === c) return c; if (!y(c)) throw q("notstring", c); for (var p = A(u) ? u : v(u) ? function () { return u } : function () { return {} }, n = c, l = [], w, m; c = n.match(h) ;) w = c[0], c[2] ||
            c[4] || (w = (c[3] ? "http://" : "mailto:") + w), m = c.index, r(n.substr(0, m)), x(w, c[0].replace(t, "")), n = n.substring(m + c[0].length); r(n); return f(l.join(""))
        }
    }])
})(window, window.angular);
//# sourceMappingURL=angular-sanitize.min.js.map