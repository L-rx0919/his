import{d as e,r as a,d1 as l,R as o,aG as t,ap as s,e as r,f as d,w as n,m as u,i,aj as p,E as m}from"./index.ZLNrSxa7.js";import{E as c}from"./el-card.DbBDXnab.js";import{E as f}from"./el-tree.CKy2Xbl5.js";import"./el-checkbox.BmPwdX9L.js";import{E as h}from"./el-input.DEr4JItJ.js";import{D as v}from"./dept.1DnAdbAi.js";const b=e({__name:"DeptTree",props:{modelValue:{type:[Number],default:void 0}},emits:["node-click"],setup(e,{emit:b}){const j=e,x=a(),_=a(),k=a(),V=b,E=l(j,"modelValue",V);function N(e,a){return!e||-1!==a.label.indexOf(e)}function w(e){E.value=e.value,V("node-click")}return o((()=>{_.value.filter(k.value)}),{flush:"post"}),t((()=>{v.getOptions().then((e=>{x.value=e}))})),(e,a)=>{const l=s("Search"),o=m,t=h,v=f,b=c;return d(),r(b,{shadow:"never"},{default:n((()=>[u(t,{modelValue:i(k),"onUpdate:modelValue":a[0]||(a[0]=e=>p(k)?k.value=e:null),placeholder:"部门名称",clearable:""},{prefix:n((()=>[u(o,null,{default:n((()=>[u(l)])),_:1})])),_:1},8,["modelValue"]),u(v,{ref_key:"deptTreeRef",ref:_,class:"mt-2",data:i(x),props:{children:"children",label:"label",disabled:""},"expand-on-click-node":!1,"filter-node-method":N,"default-expand-all":"",onNodeClick:w},null,8,["data"])])),_:1})}}});export{b as _};
