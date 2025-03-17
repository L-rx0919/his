import{t as e,_ as a,d as s,br as t,c as l,r as o,b as r,x as d,J as i,e as n,f,w as c,m as u,T as p,i as v,V as b,C as y,U as m,j as h,g as C,h as k,n as A,l as w,F as E,E as F,Y as x,X as L,q as R}from"./index.ZLNrSxa7.js";import{d as _,a as g,u as T,E as $}from"./el-overlay.TtYSBS3d.js";import{E as S,a as j}from"./index.CAmgOVMc.js";import{u as z}from"./index.D_Z5gYVY.js";const B=e({...g,direction:{type:String,default:"rtl",values:["ltr","rtl","ttb","btt"]},size:{type:[String,Number],default:"30%"},withHeader:{type:Boolean,default:!0},modalFade:{type:Boolean,default:!0},headerAriaLevel:{type:String,default:"2"}}),q=_,I=s({name:"ElDrawer",inheritAttrs:!1});const P=R(a(s({...I,props:B,emits:q,setup(e,{expose:a}){const s=e,R=t();z({scope:"el-drawer",from:"the title slot",replacement:"the header slot",version:"3.0.0",ref:"https://element-plus.org/en-US/component/drawer.html#slots"},l((()=>!!R.title)));const _=o(),g=o(),B=r("drawer"),{t:q}=d(),{afterEnter:I,afterLeave:P,beforeLeave:D,visible:H,rendered:J,titleId:O,bodyId:U,zIndex:M,onModalClick:N,onOpenAutoFocus:V,onCloseAutoFocus:X,onFocusoutPrevented:Y,onCloseRequested:G,handleClose:K}=T(s,_),Q=l((()=>"rtl"===s.direction||"ltr"===s.direction)),W=l((()=>i(s.size)));return a({handleClose:K,afterEnter:I,afterLeave:P}),(e,a)=>(f(),n(v(j),{to:e.appendTo,disabled:"body"===e.appendTo&&!e.appendToBody},{default:c((()=>[u(p,{name:v(B).b("fade"),onAfterEnter:v(I),onAfterLeave:v(P),onBeforeLeave:v(D),persisted:""},{default:c((()=>[b(u(v($),{mask:e.modal,"overlay-class":e.modalClass,"z-index":v(M),onClick:v(N)},{default:c((()=>[u(v(S),{loop:"",trapped:v(H),"focus-trap-el":_.value,"focus-start-el":g.value,onFocusAfterTrapped:v(V),onFocusAfterReleased:v(X),onFocusoutPrevented:v(Y),onReleaseRequested:v(G)},{default:c((()=>[y("div",m({ref_key:"drawerRef",ref:_,"aria-modal":"true","aria-label":e.title||void 0,"aria-labelledby":e.title?void 0:v(O),"aria-describedby":v(U)},e.$attrs,{class:[v(B).b(),e.direction,v(H)&&"open"],style:v(Q)?"width: "+v(W):"height: "+v(W),role:"dialog",onClick:h((()=>{}),["stop"])}),[y("span",{ref_key:"focusStartRef",ref:g,class:A(v(B).e("sr-focus")),tabindex:"-1"},null,2),e.withHeader?(f(),C("header",{key:0,class:A([v(B).e("header"),e.headerClass])},[e.$slots.title?w(e.$slots,"title",{key:1},(()=>[k(" DEPRECATED SLOT ")])):w(e.$slots,"header",{key:0,close:v(K),titleId:v(O),titleClass:v(B).e("title")},(()=>[e.$slots.title?k("v-if",!0):(f(),C("span",{key:0,id:v(O),role:"heading","aria-level":e.headerAriaLevel,class:A(v(B).e("title"))},E(e.title),11,["id","aria-level"]))])),e.showClose?(f(),C("button",{key:2,"aria-label":v(q)("el.drawer.close"),class:A(v(B).e("close-btn")),type:"button",onClick:v(K)},[u(v(F),{class:A(v(B).e("close"))},{default:c((()=>[u(v(x))])),_:1},8,["class"])],10,["aria-label","onClick"])):k("v-if",!0)],2)):k("v-if",!0),v(J)?(f(),C("div",{key:1,id:v(U),class:A([v(B).e("body"),e.bodyClass])},[w(e.$slots,"default")],10,["id"])):k("v-if",!0),e.$slots.footer?(f(),C("div",{key:2,class:A([v(B).e("footer"),e.footerClass])},[w(e.$slots,"footer")],2)):k("v-if",!0)],16,["aria-label","aria-labelledby","aria-describedby","onClick"])])),_:3},8,["trapped","focus-trap-el","focus-start-el","onFocusAfterTrapped","onFocusAfterReleased","onFocusoutPrevented","onReleaseRequested"])])),_:3},8,["mask","overlay-class","z-index","onClick"]),[[L,v(H)]])])),_:3},8,["name","onAfterEnter","onAfterLeave","onBeforeLeave"])])),_:3},8,["to","disabled"]))}}),[["__file","drawer.vue"]]));export{P as E};
