import{c as t,A as e,bx as r,r as a,br as o,bF as n,t as i,z as s,bC as c,v as l,N as h,b as u,_ as f,d,e as g,f as p,w as b,g as v,h as m,P as y,l as x,i as k,E as w,n as S,D as M,U as A,y as H,S as B,ad as R,q as _,G as F}from"./index.ZLNrSxa7.js";import{u as N}from"./index.D_Z5gYVY.js";import{u as $,a as V,b as E}from"./use-form-common-props.C1EZqqFQ.js";const I=Symbol("buttonGroupContextKey"),q=i({size:h,disabled:Boolean,type:{type:String,values:["default","primary","success","warning","info","danger","text",""],default:""},icon:{type:l},nativeType:{type:String,values:["button","submit","reset"],default:"button"},loading:Boolean,loadingIcon:{type:l,default:()=>c},plain:Boolean,text:Boolean,link:Boolean,bg:Boolean,autofocus:Boolean,round:Boolean,circle:Boolean,color:String,dark:Boolean,autoInsertSpace:{type:Boolean,default:void 0},tag:{type:s([String,Object]),default:"button"}}),z={click:t=>t instanceof MouseEvent};function j(t,e){(function(t){return"string"==typeof t&&-1!==t.indexOf(".")&&1===parseFloat(t)})(t)&&(t="100%");var r=function(t){return"string"==typeof t&&-1!==t.indexOf("%")}(t);return t=360===e?t:Math.min(e,Math.max(0,parseFloat(t))),r&&(t=parseInt(String(t*e),10)/100),Math.abs(t-e)<1e-6?1:t=360===e?(t<0?t%e+e:t%e)/parseFloat(String(e)):t%e/parseFloat(String(e))}function C(t){return Math.min(1,Math.max(0,t))}function T(t){return t=parseFloat(t),(isNaN(t)||t<0||t>1)&&(t=1),t}function W(t){return t<=1?"".concat(100*Number(t),"%"):t}function P(t){return 1===t.length?"0"+t:String(t)}function O(t,e,r){t=j(t,255),e=j(e,255),r=j(r,255);var a=Math.max(t,e,r),o=Math.min(t,e,r),n=0,i=0,s=(a+o)/2;if(a===o)i=0,n=0;else{var c=a-o;switch(i=s>.5?c/(2-a-o):c/(a+o),a){case t:n=(e-r)/c+(e<r?6:0);break;case e:n=(r-t)/c+2;break;case r:n=(t-e)/c+4}n/=6}return{h:n,s:i,l:s}}function U(t,e,r){return r<0&&(r+=1),r>1&&(r-=1),r<1/6?t+6*r*(e-t):r<.5?e:r<2/3?t+(e-t)*(2/3-r)*6:t}function D(t,e,r){t=j(t,255),e=j(e,255),r=j(r,255);var a=Math.max(t,e,r),o=Math.min(t,e,r),n=0,i=a,s=a-o,c=0===a?0:s/a;if(a===o)n=0;else{switch(a){case t:n=(e-r)/s+(e<r?6:0);break;case e:n=(r-t)/s+2;break;case r:n=(t-e)/s+4}n/=6}return{h:n,s:c,v:i}}function G(t,e,r,a){var o=[P(Math.round(t).toString(16)),P(Math.round(e).toString(16)),P(Math.round(r).toString(16))];return a&&o[0].startsWith(o[0].charAt(1))&&o[1].startsWith(o[1].charAt(1))&&o[2].startsWith(o[2].charAt(1))?o[0].charAt(0)+o[1].charAt(0)+o[2].charAt(0):o.join("")}function L(t){return K(t)/255}function K(t){return parseInt(t,16)}var J={aliceblue:"#f0f8ff",antiquewhite:"#faebd7",aqua:"#00ffff",aquamarine:"#7fffd4",azure:"#f0ffff",beige:"#f5f5dc",bisque:"#ffe4c4",black:"#000000",blanchedalmond:"#ffebcd",blue:"#0000ff",blueviolet:"#8a2be2",brown:"#a52a2a",burlywood:"#deb887",cadetblue:"#5f9ea0",chartreuse:"#7fff00",chocolate:"#d2691e",coral:"#ff7f50",cornflowerblue:"#6495ed",cornsilk:"#fff8dc",crimson:"#dc143c",cyan:"#00ffff",darkblue:"#00008b",darkcyan:"#008b8b",darkgoldenrod:"#b8860b",darkgray:"#a9a9a9",darkgreen:"#006400",darkgrey:"#a9a9a9",darkkhaki:"#bdb76b",darkmagenta:"#8b008b",darkolivegreen:"#556b2f",darkorange:"#ff8c00",darkorchid:"#9932cc",darkred:"#8b0000",darksalmon:"#e9967a",darkseagreen:"#8fbc8f",darkslateblue:"#483d8b",darkslategray:"#2f4f4f",darkslategrey:"#2f4f4f",darkturquoise:"#00ced1",darkviolet:"#9400d3",deeppink:"#ff1493",deepskyblue:"#00bfff",dimgray:"#696969",dimgrey:"#696969",dodgerblue:"#1e90ff",firebrick:"#b22222",floralwhite:"#fffaf0",forestgreen:"#228b22",fuchsia:"#ff00ff",gainsboro:"#dcdcdc",ghostwhite:"#f8f8ff",goldenrod:"#daa520",gold:"#ffd700",gray:"#808080",green:"#008000",greenyellow:"#adff2f",grey:"#808080",honeydew:"#f0fff0",hotpink:"#ff69b4",indianred:"#cd5c5c",indigo:"#4b0082",ivory:"#fffff0",khaki:"#f0e68c",lavenderblush:"#fff0f5",lavender:"#e6e6fa",lawngreen:"#7cfc00",lemonchiffon:"#fffacd",lightblue:"#add8e6",lightcoral:"#f08080",lightcyan:"#e0ffff",lightgoldenrodyellow:"#fafad2",lightgray:"#d3d3d3",lightgreen:"#90ee90",lightgrey:"#d3d3d3",lightpink:"#ffb6c1",lightsalmon:"#ffa07a",lightseagreen:"#20b2aa",lightskyblue:"#87cefa",lightslategray:"#778899",lightslategrey:"#778899",lightsteelblue:"#b0c4de",lightyellow:"#ffffe0",lime:"#00ff00",limegreen:"#32cd32",linen:"#faf0e6",magenta:"#ff00ff",maroon:"#800000",mediumaquamarine:"#66cdaa",mediumblue:"#0000cd",mediumorchid:"#ba55d3",mediumpurple:"#9370db",mediumseagreen:"#3cb371",mediumslateblue:"#7b68ee",mediumspringgreen:"#00fa9a",mediumturquoise:"#48d1cc",mediumvioletred:"#c71585",midnightblue:"#191970",mintcream:"#f5fffa",mistyrose:"#ffe4e1",moccasin:"#ffe4b5",navajowhite:"#ffdead",navy:"#000080",oldlace:"#fdf5e6",olive:"#808000",olivedrab:"#6b8e23",orange:"#ffa500",orangered:"#ff4500",orchid:"#da70d6",palegoldenrod:"#eee8aa",palegreen:"#98fb98",paleturquoise:"#afeeee",palevioletred:"#db7093",papayawhip:"#ffefd5",peachpuff:"#ffdab9",peru:"#cd853f",pink:"#ffc0cb",plum:"#dda0dd",powderblue:"#b0e0e6",purple:"#800080",rebeccapurple:"#663399",red:"#ff0000",rosybrown:"#bc8f8f",royalblue:"#4169e1",saddlebrown:"#8b4513",salmon:"#fa8072",sandybrown:"#f4a460",seagreen:"#2e8b57",seashell:"#fff5ee",sienna:"#a0522d",silver:"#c0c0c0",skyblue:"#87ceeb",slateblue:"#6a5acd",slategray:"#708090",slategrey:"#708090",snow:"#fffafa",springgreen:"#00ff7f",steelblue:"#4682b4",tan:"#d2b48c",teal:"#008080",thistle:"#d8bfd8",tomato:"#ff6347",turquoise:"#40e0d0",violet:"#ee82ee",wheat:"#f5deb3",white:"#ffffff",whitesmoke:"#f5f5f5",yellow:"#ffff00",yellowgreen:"#9acd32"};function Q(t){var e,r,a,o={r:0,g:0,b:0},n=1,i=null,s=null,c=null,l=!1,h=!1;return"string"==typeof t&&(t=function(t){if(t=t.trim().toLowerCase(),0===t.length)return!1;var e=!1;if(J[t])t=J[t],e=!0;else if("transparent"===t)return{r:0,g:0,b:0,a:0,format:"name"};var r=tt.rgb.exec(t);if(r)return{r:r[1],g:r[2],b:r[3]};if(r=tt.rgba.exec(t),r)return{r:r[1],g:r[2],b:r[3],a:r[4]};if(r=tt.hsl.exec(t),r)return{h:r[1],s:r[2],l:r[3]};if(r=tt.hsla.exec(t),r)return{h:r[1],s:r[2],l:r[3],a:r[4]};if(r=tt.hsv.exec(t),r)return{h:r[1],s:r[2],v:r[3]};if(r=tt.hsva.exec(t),r)return{h:r[1],s:r[2],v:r[3],a:r[4]};if(r=tt.hex8.exec(t),r)return{r:K(r[1]),g:K(r[2]),b:K(r[3]),a:L(r[4]),format:e?"name":"hex8"};if(r=tt.hex6.exec(t),r)return{r:K(r[1]),g:K(r[2]),b:K(r[3]),format:e?"name":"hex"};if(r=tt.hex4.exec(t),r)return{r:K(r[1]+r[1]),g:K(r[2]+r[2]),b:K(r[3]+r[3]),a:L(r[4]+r[4]),format:e?"name":"hex8"};if(r=tt.hex3.exec(t),r)return{r:K(r[1]+r[1]),g:K(r[2]+r[2]),b:K(r[3]+r[3]),format:e?"name":"hex"};return!1}(t)),"object"==typeof t&&(et(t.r)&&et(t.g)&&et(t.b)?(e=t.r,r=t.g,a=t.b,o={r:255*j(e,255),g:255*j(r,255),b:255*j(a,255)},l=!0,h="%"===String(t.r).substr(-1)?"prgb":"rgb"):et(t.h)&&et(t.s)&&et(t.v)?(i=W(t.s),s=W(t.v),o=function(t,e,r){t=6*j(t,360),e=j(e,100),r=j(r,100);var a=Math.floor(t),o=t-a,n=r*(1-e),i=r*(1-o*e),s=r*(1-(1-o)*e),c=a%6;return{r:255*[r,i,n,n,s,r][c],g:255*[s,r,r,i,n,n][c],b:255*[n,n,s,r,r,i][c]}}(t.h,i,s),l=!0,h="hsv"):et(t.h)&&et(t.s)&&et(t.l)&&(i=W(t.s),c=W(t.l),o=function(t,e,r){var a,o,n;if(t=j(t,360),e=j(e,100),r=j(r,100),0===e)o=r,n=r,a=r;else{var i=r<.5?r*(1+e):r+e-r*e,s=2*r-i;a=U(s,i,t+1/3),o=U(s,i,t),n=U(s,i,t-1/3)}return{r:255*a,g:255*o,b:255*n}}(t.h,i,c),l=!0,h="hsl"),Object.prototype.hasOwnProperty.call(t,"a")&&(n=t.a)),n=T(n),{ok:l,format:t.format||h,r:Math.min(255,Math.max(o.r,0)),g:Math.min(255,Math.max(o.g,0)),b:Math.min(255,Math.max(o.b,0)),a:n}}var X="(?:".concat("[-\\+]?\\d*\\.\\d+%?",")|(?:").concat("[-\\+]?\\d+%?",")"),Y="[\\s|\\(]+(".concat(X,")[,|\\s]+(").concat(X,")[,|\\s]+(").concat(X,")\\s*\\)?"),Z="[\\s|\\(]+(".concat(X,")[,|\\s]+(").concat(X,")[,|\\s]+(").concat(X,")[,|\\s]+(").concat(X,")\\s*\\)?"),tt={CSS_UNIT:new RegExp(X),rgb:new RegExp("rgb"+Y),rgba:new RegExp("rgba"+Z),hsl:new RegExp("hsl"+Y),hsla:new RegExp("hsla"+Z),hsv:new RegExp("hsv"+Y),hsva:new RegExp("hsva"+Z),hex3:/^#?([0-9a-fA-F]{1})([0-9a-fA-F]{1})([0-9a-fA-F]{1})$/,hex6:/^#?([0-9a-fA-F]{2})([0-9a-fA-F]{2})([0-9a-fA-F]{2})$/,hex4:/^#?([0-9a-fA-F]{1})([0-9a-fA-F]{1})([0-9a-fA-F]{1})([0-9a-fA-F]{1})$/,hex8:/^#?([0-9a-fA-F]{2})([0-9a-fA-F]{2})([0-9a-fA-F]{2})([0-9a-fA-F]{2})$/};function et(t){return Boolean(tt.CSS_UNIT.exec(String(t)))}var rt=function(){function t(e,r){var a;if(void 0===e&&(e=""),void 0===r&&(r={}),e instanceof t)return e;"number"==typeof e&&(e=function(t){return{r:t>>16,g:(65280&t)>>8,b:255&t}}(e)),this.originalInput=e;var o=Q(e);this.originalInput=e,this.r=o.r,this.g=o.g,this.b=o.b,this.a=o.a,this.roundA=Math.round(100*this.a)/100,this.format=null!==(a=r.format)&&void 0!==a?a:o.format,this.gradientType=r.gradientType,this.r<1&&(this.r=Math.round(this.r)),this.g<1&&(this.g=Math.round(this.g)),this.b<1&&(this.b=Math.round(this.b)),this.isValid=o.ok}return t.prototype.isDark=function(){return this.getBrightness()<128},t.prototype.isLight=function(){return!this.isDark()},t.prototype.getBrightness=function(){var t=this.toRgb();return(299*t.r+587*t.g+114*t.b)/1e3},t.prototype.getLuminance=function(){var t=this.toRgb(),e=t.r/255,r=t.g/255,a=t.b/255;return.2126*(e<=.03928?e/12.92:Math.pow((e+.055)/1.055,2.4))+.7152*(r<=.03928?r/12.92:Math.pow((r+.055)/1.055,2.4))+.0722*(a<=.03928?a/12.92:Math.pow((a+.055)/1.055,2.4))},t.prototype.getAlpha=function(){return this.a},t.prototype.setAlpha=function(t){return this.a=T(t),this.roundA=Math.round(100*this.a)/100,this},t.prototype.isMonochrome=function(){return 0===this.toHsl().s},t.prototype.toHsv=function(){var t=D(this.r,this.g,this.b);return{h:360*t.h,s:t.s,v:t.v,a:this.a}},t.prototype.toHsvString=function(){var t=D(this.r,this.g,this.b),e=Math.round(360*t.h),r=Math.round(100*t.s),a=Math.round(100*t.v);return 1===this.a?"hsv(".concat(e,", ").concat(r,"%, ").concat(a,"%)"):"hsva(".concat(e,", ").concat(r,"%, ").concat(a,"%, ").concat(this.roundA,")")},t.prototype.toHsl=function(){var t=O(this.r,this.g,this.b);return{h:360*t.h,s:t.s,l:t.l,a:this.a}},t.prototype.toHslString=function(){var t=O(this.r,this.g,this.b),e=Math.round(360*t.h),r=Math.round(100*t.s),a=Math.round(100*t.l);return 1===this.a?"hsl(".concat(e,", ").concat(r,"%, ").concat(a,"%)"):"hsla(".concat(e,", ").concat(r,"%, ").concat(a,"%, ").concat(this.roundA,")")},t.prototype.toHex=function(t){return void 0===t&&(t=!1),G(this.r,this.g,this.b,t)},t.prototype.toHexString=function(t){return void 0===t&&(t=!1),"#"+this.toHex(t)},t.prototype.toHex8=function(t){return void 0===t&&(t=!1),function(t,e,r,a,o){var n,i=[P(Math.round(t).toString(16)),P(Math.round(e).toString(16)),P(Math.round(r).toString(16)),P((n=a,Math.round(255*parseFloat(n)).toString(16)))];return o&&i[0].startsWith(i[0].charAt(1))&&i[1].startsWith(i[1].charAt(1))&&i[2].startsWith(i[2].charAt(1))&&i[3].startsWith(i[3].charAt(1))?i[0].charAt(0)+i[1].charAt(0)+i[2].charAt(0)+i[3].charAt(0):i.join("")}(this.r,this.g,this.b,this.a,t)},t.prototype.toHex8String=function(t){return void 0===t&&(t=!1),"#"+this.toHex8(t)},t.prototype.toHexShortString=function(t){return void 0===t&&(t=!1),1===this.a?this.toHexString(t):this.toHex8String(t)},t.prototype.toRgb=function(){return{r:Math.round(this.r),g:Math.round(this.g),b:Math.round(this.b),a:this.a}},t.prototype.toRgbString=function(){var t=Math.round(this.r),e=Math.round(this.g),r=Math.round(this.b);return 1===this.a?"rgb(".concat(t,", ").concat(e,", ").concat(r,")"):"rgba(".concat(t,", ").concat(e,", ").concat(r,", ").concat(this.roundA,")")},t.prototype.toPercentageRgb=function(){var t=function(t){return"".concat(Math.round(100*j(t,255)),"%")};return{r:t(this.r),g:t(this.g),b:t(this.b),a:this.a}},t.prototype.toPercentageRgbString=function(){var t=function(t){return Math.round(100*j(t,255))};return 1===this.a?"rgb(".concat(t(this.r),"%, ").concat(t(this.g),"%, ").concat(t(this.b),"%)"):"rgba(".concat(t(this.r),"%, ").concat(t(this.g),"%, ").concat(t(this.b),"%, ").concat(this.roundA,")")},t.prototype.toName=function(){if(0===this.a)return"transparent";if(this.a<1)return!1;for(var t="#"+G(this.r,this.g,this.b,!1),e=0,r=Object.entries(J);e<r.length;e++){var a=r[e],o=a[0];if(t===a[1])return o}return!1},t.prototype.toString=function(t){var e=Boolean(t);t=null!=t?t:this.format;var r=!1,a=this.a<1&&this.a>=0;return e||!a||!t.startsWith("hex")&&"name"!==t?("rgb"===t&&(r=this.toRgbString()),"prgb"===t&&(r=this.toPercentageRgbString()),"hex"!==t&&"hex6"!==t||(r=this.toHexString()),"hex3"===t&&(r=this.toHexString(!0)),"hex4"===t&&(r=this.toHex8String(!0)),"hex8"===t&&(r=this.toHex8String()),"name"===t&&(r=this.toName()),"hsl"===t&&(r=this.toHslString()),"hsv"===t&&(r=this.toHsvString()),r||this.toHexString()):"name"===t&&0===this.a?this.toName():this.toRgbString()},t.prototype.toNumber=function(){return(Math.round(this.r)<<16)+(Math.round(this.g)<<8)+Math.round(this.b)},t.prototype.clone=function(){return new t(this.toString())},t.prototype.lighten=function(e){void 0===e&&(e=10);var r=this.toHsl();return r.l+=e/100,r.l=C(r.l),new t(r)},t.prototype.brighten=function(e){void 0===e&&(e=10);var r=this.toRgb();return r.r=Math.max(0,Math.min(255,r.r-Math.round(-e/100*255))),r.g=Math.max(0,Math.min(255,r.g-Math.round(-e/100*255))),r.b=Math.max(0,Math.min(255,r.b-Math.round(-e/100*255))),new t(r)},t.prototype.darken=function(e){void 0===e&&(e=10);var r=this.toHsl();return r.l-=e/100,r.l=C(r.l),new t(r)},t.prototype.tint=function(t){return void 0===t&&(t=10),this.mix("white",t)},t.prototype.shade=function(t){return void 0===t&&(t=10),this.mix("black",t)},t.prototype.desaturate=function(e){void 0===e&&(e=10);var r=this.toHsl();return r.s-=e/100,r.s=C(r.s),new t(r)},t.prototype.saturate=function(e){void 0===e&&(e=10);var r=this.toHsl();return r.s+=e/100,r.s=C(r.s),new t(r)},t.prototype.greyscale=function(){return this.desaturate(100)},t.prototype.spin=function(e){var r=this.toHsl(),a=(r.h+e)%360;return r.h=a<0?360+a:a,new t(r)},t.prototype.mix=function(e,r){void 0===r&&(r=50);var a=this.toRgb(),o=new t(e).toRgb(),n=r/100;return new t({r:(o.r-a.r)*n+a.r,g:(o.g-a.g)*n+a.g,b:(o.b-a.b)*n+a.b,a:(o.a-a.a)*n+a.a})},t.prototype.analogous=function(e,r){void 0===e&&(e=6),void 0===r&&(r=30);var a=this.toHsl(),o=360/r,n=[this];for(a.h=(a.h-(o*e>>1)+720)%360;--e;)a.h=(a.h+o)%360,n.push(new t(a));return n},t.prototype.complement=function(){var e=this.toHsl();return e.h=(e.h+180)%360,new t(e)},t.prototype.monochromatic=function(e){void 0===e&&(e=6);for(var r=this.toHsv(),a=r.h,o=r.s,n=r.v,i=[],s=1/e;e--;)i.push(new t({h:a,s:o,v:n})),n=(n+s)%1;return i},t.prototype.splitcomplement=function(){var e=this.toHsl(),r=e.h;return[this,new t({h:(r+72)%360,s:e.s,l:e.l}),new t({h:(r+216)%360,s:e.s,l:e.l})]},t.prototype.onBackground=function(e){var r=this.toRgb(),a=new t(e).toRgb(),o=r.a+a.a*(1-r.a);return new t({r:(r.r*r.a+a.r*a.a*(1-r.a))/o,g:(r.g*r.a+a.g*a.a*(1-r.a))/o,b:(r.b*r.a+a.b*a.a*(1-r.a))/o,a:o})},t.prototype.triad=function(){return this.polyad(3)},t.prototype.tetrad=function(){return this.polyad(4)},t.prototype.polyad=function(e){for(var r=this.toHsl(),a=r.h,o=[this],n=360/e,i=1;i<e;i++)o.push(new t({h:(a+i*n)%360,s:r.s,l:r.l}));return o},t.prototype.equals=function(e){return this.toRgbString()===new t(e).toRgbString()},t}();function at(t,e=20){return t.mix("#141414",e).toString()}const ot=d({name:"ElButton"});var nt=f(d({...ot,props:q,emits:z,setup(i,{expose:s,emit:c}){const l=i,h=function(e){const r=E(),a=u("button");return t((()=>{let t={},o=e.color;if(o){const n=o.match(/var\((.*?)\)/);n&&(o=window.getComputedStyle(window.document.documentElement).getPropertyValue(n[1]));const i=new rt(o),s=e.dark?i.tint(20).toString():at(i,20);if(e.plain)t=a.cssVarBlock({"bg-color":e.dark?at(i,90):i.tint(90).toString(),"text-color":o,"border-color":e.dark?at(i,50):i.tint(50).toString(),"hover-text-color":`var(${a.cssVarName("color-white")})`,"hover-bg-color":o,"hover-border-color":o,"active-bg-color":s,"active-text-color":`var(${a.cssVarName("color-white")})`,"active-border-color":s}),r.value&&(t[a.cssVarBlockName("disabled-bg-color")]=e.dark?at(i,90):i.tint(90).toString(),t[a.cssVarBlockName("disabled-text-color")]=e.dark?at(i,50):i.tint(50).toString(),t[a.cssVarBlockName("disabled-border-color")]=e.dark?at(i,80):i.tint(80).toString());else{const n=e.dark?at(i,30):i.tint(30).toString(),c=i.isDark()?`var(${a.cssVarName("color-white")})`:`var(${a.cssVarName("color-black")})`;if(t=a.cssVarBlock({"bg-color":o,"text-color":c,"border-color":o,"hover-bg-color":n,"hover-text-color":c,"hover-border-color":n,"active-bg-color":s,"active-border-color":s}),r.value){const r=e.dark?at(i,50):i.tint(50).toString();t[a.cssVarBlockName("disabled-bg-color")]=r,t[a.cssVarBlockName("disabled-text-color")]=e.dark?"rgba(255, 255, 255, 0.5)":`var(${a.cssVarName("color-white")})`,t[a.cssVarBlockName("disabled-border-color")]=r}}}return t}))}(l),f=u("button"),{_ref:d,_size:H,_type:B,_disabled:R,_props:_,shouldAddSpace:F,handleClick:q}=((i,s)=>{N({from:"type.text",replacement:"link",version:"3.0.0",scope:"props",ref:"https://element-plus.org/en-US/component/button.html#button-attributes"},t((()=>"text"===i.type)));const c=e(I,void 0),l=r("button"),{form:h}=$(),u=V(t((()=>null==c?void 0:c.size))),f=E(),d=a(),g=o(),p=t((()=>i.type||(null==c?void 0:c.type)||"")),b=t((()=>{var t,e,r;return null!=(r=null!=(e=i.autoInsertSpace)?e:null==(t=l.value)?void 0:t.autoInsertSpace)&&r})),v=t((()=>"button"===i.tag?{ariaDisabled:f.value||i.loading,disabled:f.value||i.loading,autofocus:i.autofocus,type:i.nativeType}:{})),m=t((()=>{var t;const e=null==(t=g.default)?void 0:t.call(g);if(b.value&&1===(null==e?void 0:e.length)){const t=e[0];if((null==t?void 0:t.type)===n){const e=t.children;return new RegExp("^\\p{Unified_Ideograph}{2}$","u").test(e.trim())}}return!1}));return{_disabled:f,_size:u,_type:p,_ref:d,_props:v,shouldAddSpace:m,handleClick:t=>{f.value||i.loading?t.stopPropagation():("reset"===i.nativeType&&(null==h||h.resetFields()),s("click",t))}}})(l,c),z=t((()=>[f.b(),f.m(B.value),f.m(H.value),f.is("disabled",R.value),f.is("loading",l.loading),f.is("plain",l.plain),f.is("round",l.round),f.is("circle",l.circle),f.is("text",l.text),f.is("link",l.link),f.is("has-bg",l.bg)]));return s({ref:d,size:H,type:B,disabled:R,shouldAddSpace:F}),(t,e)=>(p(),g(M(t.tag),A({ref_key:"_ref",ref:d},k(_),{class:k(z),style:k(h),onClick:k(q)}),{default:b((()=>[t.loading?(p(),v(y,{key:0},[t.$slots.loading?x(t.$slots,"loading",{key:0}):(p(),g(k(w),{key:1,class:S(k(f).is("loading"))},{default:b((()=>[(p(),g(M(t.loadingIcon)))])),_:1},8,["class"]))],64)):t.icon||t.$slots.icon?(p(),g(k(w),{key:1},{default:b((()=>[t.icon?(p(),g(M(t.icon),{key:0})):x(t.$slots,"icon",{key:1})])),_:3})):m("v-if",!0),t.$slots.default?(p(),v("span",{key:2,class:S({[k(f).em("text","expand")]:k(F)})},[x(t.$slots,"default")],2)):m("v-if",!0)])),_:3},16,["class","style","onClick"]))}}),[["__file","button.vue"]]);const it={size:q.size,type:q.type},st=d({name:"ElButtonGroup"});var ct=f(d({...st,props:it,setup(t){const e=t;H(I,B({size:R(e,"size"),type:R(e,"type")}));const r=u("button");return(t,e)=>(p(),v("div",{class:S(k(r).b("group"))},[x(t.$slots,"default")],2))}}),[["__file","button-group.vue"]]);const lt=_(nt,{ButtonGroup:ct});F(ct);export{lt as E,rt as T};
