import{d as e,aE as a,al as s,aI as l,aA as o,r,an as t,c as i,o as n,g as p,C as d,m,aj as u,i as c,w as g,aJ as f,ag as h,ap as v,f as _,F as j,aw as w,E as y,$ as x,Z as C,j as b,ay as E}from"./index.ZLNrSxa7.js";import{E as k,a as q}from"./el-form-item.CSlDAgNu.js";import{E as V}from"./el-divider.C9A23nko.js";import{E as K}from"./el-text.fcqqDvex.js";import{E as U}from"./el-button.DSrO3PCY.js";import{E as $}from"./el-link.DKQSWj_6.js";import{E as R}from"./el-checkbox.BmPwdX9L.js";import{E as A}from"./el-image-viewer.D3svABDR.js";import"./el-tooltip.l0sNRNKZ.js";import{E as L}from"./el-popper.B221JJYw.js";import{E as z}from"./el-input.DEr4JItJ.js";import{_ as P,E as I,a as M,b as D}from"./index.vue_vue_type_script_setup_true_lang.VVd8O8uh.js";import"./el-scrollbar.ET7HVX21.js";/* empty css               */import{E as S}from"./el-switch.DySbRw45.js";import{E as F}from"./index.CjPWYcvS.js";import{_ as T}from"./_plugin-vue_export-helper.BCo6x5W8.js";import"./use-form-common-props.C1EZqqFQ.js";import"./castArray.BeWz_jd2.js";import"./error.CmW-dgG_.js";import"./_Uint8Array.DXkM4Snb.js";import"./index.D_Z5gYVY.js";import"./index.C7eagngv.js";import"./isEqual.DHfRWznk.js";import"./index.CAmgOVMc.js";import"./scroll.CuImcdyA.js";import"./position.BOqJ06QS.js";import"./index.BnUUwnwX.js";import"./index.BQb3_wVy.js";import"./dropdown.Bwyb33ll.js";import"./refs.CwYjimeG.js";import"./validator.DGpTlVtL.js";const Z={class:"login"},B={class:"login-header"},G={class:"flex-y-center"},H={class:"login-form"},J={class:"form-title"},Q={class:"cursor-pointer"},W={class:"input-wrapper"},X={class:"input-wrapper"},Y={class:"input-wrapper"},N={class:"flex-x-between w-full py-1"},O={class:"login-footer"},ee=T(e({__name:"index",setup(e){const T=a(),ee=s(),ae=l(),se=h(),{t:le}=o(),oe=r(),re=r(ee.theme===t.DARK),te=r(!1),ie=r(!1),ne=r(),pe=r({username:"admin",password:"admin123",captchaKey:"",captchaCode:""}),de=i((()=>({username:[{required:!0,trigger:"blur",message:le("login.message.username.required")}],password:[{required:!0,trigger:"blur",message:le("login.message.password.required")},{min:6,message:le("login.message.password.min"),trigger:"blur"}],captchaCode:[{required:!0,trigger:"blur",message:le("login.message.captchaCode.required")}]})));function me(){f.getCaptcha().then((e=>{pe.value.captchaKey=e.captchaKey,ne.value=e.captchaBase64}))}async function ue(){var e;null==(e=oe.value)||e.validate((e=>{e&&(te.value=!0,T.login(pe.value).then((async()=>{await T.getUserInfo(),await ae.loadDictionaries();const{path:e,queryParams:a}=function(){const e=se.query.redirect??"/",a=new URL(e,window.location.origin),s=a.pathname,l={};return a.searchParams.forEach(((e,a)=>{l[a]=e})),{path:s,queryParams:l}}();E.push({path:e,query:a})})).catch((()=>{me()})).finally((()=>{te.value=!1})))}))}const ce=()=>{const e=ee.theme===t.DARK?t.LIGHT:t.DARK;ee.changeTheme(e)};function ge(e){e instanceof KeyboardEvent&&(ie.value=e.getModifierState("CapsLock"))}const fe=(e,a)=>{pe.value.username=e,pe.value.password=a};return n((()=>{me()})),(e,a)=>{const s=S,l=P,o=v("arrow-down"),r=y,t=F,i=D,n=M,f=I,h=v("User"),E=z,T=q,ee=v("Lock"),ae=L,se=A,le=R,he=$,ve=U,_e=K,je=V,we=k;return _(),p("div",Z,[d("div",B,[d("div",G,[m(s,{modelValue:c(re),"onUpdate:modelValue":a[0]||(a[0]=e=>u(re)?re.value=e:null),"inline-prompt":"","active-icon":"Moon","inactive-icon":"Sunny",onChange:ce},null,8,["modelValue"]),m(l,{class:"ml-2 cursor-pointer"})])]),d("div",H,[m(we,{ref_key:"loginFormRef",ref:oe,model:c(pe),rules:c(de)},{default:g((()=>[d("div",J,[d("h2",null,j(c(w).title),1),m(f,{style:{position:"absolute",right:"0"}},{dropdown:g((()=>[m(n,null,{default:g((()=>[m(i,null,{default:g((()=>[m(t,null,{default:g((()=>[x(j(c(w).version),1)])),_:1})])),_:1}),m(i,{onClick:a[1]||(a[1]=e=>fe("root","123456"))},{default:g((()=>a[7]||(a[7]=[x(" 超级管理员：root/123456 ")]))),_:1}),m(i,{onClick:a[2]||(a[2]=e=>fe("admin","123456"))},{default:g((()=>a[8]||(a[8]=[x(" 系统管理员：admin/123456 ")]))),_:1}),m(i,{onClick:a[3]||(a[3]=e=>fe("test","123456"))},{default:g((()=>a[9]||(a[9]=[x(" 测试小游客：test/123456 ")]))),_:1})])),_:1})])),default:g((()=>[d("div",Q,[m(r,null,{default:g((()=>[m(o)])),_:1})])])),_:1})]),m(T,{prop:"username"},{default:g((()=>[d("div",W,[m(r,{class:"mx-2"},{default:g((()=>[m(h)])),_:1}),m(E,{ref:"username",modelValue:c(pe).username,"onUpdate:modelValue":a[4]||(a[4]=e=>c(pe).username=e),placeholder:e.$t("login.username"),name:"username",size:"large",class:"h-[48px]"},null,8,["modelValue","placeholder"])])])),_:1}),m(ae,{visible:c(ie),content:e.$t("login.capsLock"),placement:"right"},{default:g((()=>[m(T,{prop:"password"},{default:g((()=>[d("div",X,[m(r,{class:"mx-2"},{default:g((()=>[m(ee)])),_:1}),m(E,{modelValue:c(pe).password,"onUpdate:modelValue":a[5]||(a[5]=e=>c(pe).password=e),placeholder:e.$t("login.password"),type:"password",name:"password",size:"large",class:"h-[48px] pr-2","show-password":"",onKeyup:[ge,C(ue,["enter"])]},null,8,["modelValue","placeholder"])])])),_:1})])),_:1},8,["visible","content"]),m(T,{prop:"captchaCode"},{default:g((()=>[d("div",Y,[a[10]||(a[10]=d("div",{class:"i-svg:captcha mx-2"},null,-1)),m(E,{modelValue:c(pe).captchaCode,"onUpdate:modelValue":a[6]||(a[6]=e=>c(pe).captchaCode=e),"auto-complete":"off",size:"large",class:"flex-1",placeholder:e.$t("login.captchaCode"),onKeyup:C(ue,["enter"])},null,8,["modelValue","placeholder"]),m(se,{src:c(ne),class:"captcha-img",onClick:me},null,8,["src"])])])),_:1}),d("div",N,[m(le,null,{default:g((()=>[x(j(e.$t("login.rememberMe")),1)])),_:1}),m(he,{type:"primary",href:"/forget-password"},{default:g((()=>[x(j(e.$t("login.forgetPassword")),1)])),_:1})]),m(ve,{loading:c(te),type:"primary",size:"large",class:"w-full",onClick:b(ue,["prevent"])},{default:g((()=>[x(j(e.$t("login.login")),1)])),_:1},8,["loading"]),m(je,null,{default:g((()=>[m(_e,{size:"small"},{default:g((()=>[x(j(e.$t("login.otherLoginMethods")),1)])),_:1})])),_:1}),a[11]||(a[11]=d("div",{class:"third-party-login"},[d("div",{class:"i-svg:wechat"}),d("div",{class:"i-svg:qq"}),d("div",{class:"i-svg:github"}),d("div",{class:"i-svg:gitee"})],-1))])),_:1},8,["model","rules"])]),d("div",O,[m(_e,{size:"small"},{default:g((()=>a[12]||(a[12]=[x(" Copyright © 2021 - 2025 youlai.tech All Rights Reserved. "),d("a",{href:"http://beian.miit.gov.cn/",target:"_blank"},"皖ICP备20006496号-2",-1)]))),_:1})])])}}}),[["__scopeId","data-v-d4f01381"]]);export{ee as default};
