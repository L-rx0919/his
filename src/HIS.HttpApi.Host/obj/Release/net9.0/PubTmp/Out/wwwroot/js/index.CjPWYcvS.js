import{t as s,aS as a,_ as e,d as o,b as l,c as n,g as t,e as c,f as i,C as r,h as u,l as p,n as m,i as d,w as f,m as k,Y as b,j as v,E as g,k as y,T as C,q as h}from"./index.ZLNrSxa7.js";import{a as T}from"./use-form-common-props.C1EZqqFQ.js";const _=s({type:{type:String,values:["primary","success","info","warning","danger"],default:"primary"},closable:Boolean,disableTransitions:Boolean,hit:Boolean,color:String,size:{type:String,values:a},effect:{type:String,values:["dark","light","plain"],default:"light"},round:Boolean}),E={close:s=>s instanceof MouseEvent,click:s=>s instanceof MouseEvent},S=o({name:"ElTag"});const B=h(e(o({...S,props:_,emits:E,setup(s,{emit:a}){const e=s,o=T(),h=l("tag"),_=n((()=>{const{type:s,hit:a,effect:l,closable:n,round:t}=e;return[h.b(),h.is("closable",n),h.m(s||"primary"),h.m(o.value),h.m(l),h.is("hit",a),h.is("round",t)]})),E=s=>{a("close",s)},S=s=>{a("click",s)},B=s=>{var a,e,o;(null==(o=null==(e=null==(a=null==s?void 0:s.component)?void 0:a.subTree)?void 0:e.component)?void 0:o.bum)&&(s.component.subTree.component.bum=null)};return(s,a)=>s.disableTransitions?(i(),t("span",{key:0,class:m(d(_)),style:y({backgroundColor:s.color}),onClick:S},[r("span",{class:m(d(h).e("content"))},[p(s.$slots,"default")],2),s.closable?(i(),c(d(g),{key:0,class:m(d(h).e("close")),onClick:v(E,["stop"])},{default:f((()=>[k(d(b))])),_:1},8,["class","onClick"])):u("v-if",!0)],6)):(i(),c(C,{key:1,name:`${d(h).namespace.value}-zoom-in-center`,appear:"",onVnodeMounted:B},{default:f((()=>[r("span",{class:m(d(_)),style:y({backgroundColor:s.color}),onClick:S},[r("span",{class:m(d(h).e("content"))},[p(s.$slots,"default")],2),s.closable?(i(),c(d(g),{key:0,class:m(d(h).e("close")),onClick:v(E,["stop"])},{default:f((()=>[k(d(b))])),_:1},8,["class","onClick"])):u("v-if",!0)],6)])),_:3},8,["name"]))}}),[["__file","tag.vue"]]));export{B as E,_ as t};
