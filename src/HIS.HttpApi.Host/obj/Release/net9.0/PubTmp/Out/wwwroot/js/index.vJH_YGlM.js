import{d as e,r as a,S as o,o as r,g as t,f as l,C as i,m as s,w as p,Z as m,i as n,$ as d,V as u,e as c,h as j,aj as f}from"./index.ZLNrSxa7.js";import{v as g}from"./el-loading.gy0Yvcin.js";import{E as h}from"./el-card.DbBDXnab.js";import{_ as b}from"./index.B2KdpD2o.js";import{a as w,E as x}from"./el-table-column.SMPDE2Gk.js";import"./el-checkbox.BmPwdX9L.js";import"./el-tooltip.l0sNRNKZ.js";import"./el-popper.B221JJYw.js";import"./el-scrollbar.ET7HVX21.js";/* empty css               */import{a as _,E as y}from"./el-form-item.CSlDAgNu.js";import{E as v}from"./el-button.DSrO3PCY.js";import{E as k}from"./el-date-picker.CiCbA5E0.js";import{E}from"./el-input.DEr4JItJ.js";import{L as T}from"./log.BmkBY-LI.js";import"./el-pagination.JQHvTzV9.js";import"./el-select.35Upkc1v.js";import"./index.CjPWYcvS.js";import"./use-form-common-props.C1EZqqFQ.js";import"./token.DWNpOE8r.js";import"./strings.C35vyqlw.js";import"./castArray.BeWz_jd2.js";import"./isEqual.DHfRWznk.js";import"./_Uint8Array.DXkM4Snb.js";import"./error.CmW-dgG_.js";import"./index.BQb3_wVy.js";import"./index.C7eagngv.js";import"./scroll.CuImcdyA.js";import"./_baseIteratee.Bs4VfSlC.js";import"./index.Cqrz8MS-.js";import"./index.D_Z5gYVY.js";import"./_plugin-vue_export-helper.BCo6x5W8.js";import"./index.CAmgOVMc.js";import"./dayjs.min.DspShc8e.js";import"./index.D2Bf9u9x.js";import"./index.BnUUwnwX.js";const V={class:"app-container"},U={class:"search-bar"},P=e({name:"Log",inheritAttrs:!1,__name:"index",setup(e){const P=a(),S=a(!1),z=a(0),A=o({pageNum:1,pageSize:10,keywords:"",createTime:["",""]}),C=a();function N(){S.value=!0,T.getPage(A).then((e=>{C.value=e.list,z.value=e.total})).finally((()=>{S.value=!1}))}function Y(){P.value.resetFields(),A.pageNum=1,A.createTime=void 0,N()}return r((()=>{N()})),(e,a)=>{const o=E,r=_,T=k,D=v,F=y,I=x,L=w,M=b,q=h,K=g;return l(),t("div",V,[i("div",U,[s(F,{ref_key:"queryFormRef",ref:P,model:n(A),inline:!0},{default:p((()=>[s(r,{prop:"keywords",label:"关键字"},{default:p((()=>[s(o,{modelValue:n(A).keywords,"onUpdate:modelValue":a[0]||(a[0]=e=>n(A).keywords=e),placeholder:"日志内容",clearable:"",onKeyup:m(N,["enter"])},null,8,["modelValue"])])),_:1}),s(r,{prop:"createTime",label:"操作时间"},{default:p((()=>[s(T,{modelValue:n(A).createTime,"onUpdate:modelValue":a[1]||(a[1]=e=>n(A).createTime=e),editable:!1,class:"!w-[240px]",type:"daterange","range-separator":"~","start-placeholder":"开始时间","end-placeholder":"截止时间","value-format":"YYYY-MM-DD"},null,8,["modelValue"])])),_:1}),s(r,null,{default:p((()=>[s(D,{type:"primary",icon:"search",onClick:N},{default:p((()=>a[5]||(a[5]=[d("搜索")]))),_:1}),s(D,{icon:"refresh",onClick:Y},{default:p((()=>a[6]||(a[6]=[d("重置")]))),_:1})])),_:1})])),_:1},8,["model"])]),s(q,{shadow:"never"},{default:p((()=>[u((l(),c(L,{data:n(C),"highlight-current-row":"",border:""},{default:p((()=>[s(I,{label:"操作时间",prop:"createTime",width:"180"}),s(I,{label:"操作人",prop:"operator",width:"120"}),s(I,{label:"日志模块",prop:"module",width:"100"}),s(I,{label:"日志内容",prop:"content","min-width":"200"}),s(I,{label:"IP 地址",prop:"ip",width:"150"}),s(I,{label:"地区",prop:"region",width:"150"}),s(I,{label:"浏览器",prop:"browser",width:"150"}),s(I,{label:"终端系统",prop:"os",width:"200","show-overflow-tooltip":""}),s(I,{label:"执行时间(ms)",prop:"executionTime",width:"150"})])),_:1},8,["data"])),[[K,n(S)]]),n(z)>0?(l(),c(M,{key:0,total:n(z),"onUpdate:total":a[2]||(a[2]=e=>f(z)?z.value=e:null),page:n(A).pageNum,"onUpdate:page":a[3]||(a[3]=e=>n(A).pageNum=e),limit:n(A).pageSize,"onUpdate:limit":a[4]||(a[4]=e=>n(A).pageSize=e),onPagination:N},null,8,["total","page","limit"])):j("",!0)])),_:1})])}}});export{P as default};
