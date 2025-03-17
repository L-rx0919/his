import{aX as e,d as l,r as a,o as t,g as o,f as r,m as d,w as i,$ as n,C as u,F as s,i as m,aj as p,P as c}from"./index.ZLNrSxa7.js";import{E as f}from"./el-dialog.B32-6Hy6.js";import"./el-overlay.TtYSBS3d.js";import{E as h,a as b}from"./el-form-item.CSlDAgNu.js";/* empty css               */import{E as j,a as y}from"./el-select.35Upkc1v.js";import"./el-scrollbar.ET7HVX21.js";import"./el-popper.B221JJYw.js";import{E as V,a as g}from"./el-table-column.SMPDE2Gk.js";import"./el-checkbox.BmPwdX9L.js";import"./el-tooltip.l0sNRNKZ.js";import{E as _}from"./el-input.DEr4JItJ.js";import{E as v}from"./el-button.DSrO3PCY.js";import"./index.CAmgOVMc.js";import"./refs.CwYjimeG.js";import"./index.D_Z5gYVY.js";import"./vnode.BzFWtM5t.js";import"./index.C7eagngv.js";import"./error.CmW-dgG_.js";import"./scroll.CuImcdyA.js";import"./use-form-common-props.C1EZqqFQ.js";import"./castArray.BeWz_jd2.js";import"./_Uint8Array.DXkM4Snb.js";import"./index.CjPWYcvS.js";import"./token.DWNpOE8r.js";import"./strings.C35vyqlw.js";import"./isEqual.DHfRWznk.js";import"./index.BQb3_wVy.js";import"./_baseIteratee.Bs4VfSlC.js";import"./index.Cqrz8MS-.js";import"./index.BnUUwnwX.js";const C="/api/v2/his/systemconfig/patientCategory",w={addConfing:l=>e({url:`${C}/NatureofPatient`,method:"post",data:l}),getForm:()=>e({url:`${C}/NatureofPatientList`,method:"get",params:{}}),deleteConfig:l=>e({url:`${C}/NatureofPatientDel/${l}`,method:"delete"})},x={class:"dialog-footer"},k=l({__name:"index",setup(e){const l=a([]);t((()=>{C()}));const C=()=>{w.getForm().then((e=>{l.value=e}))},k=a(!1),U=a({natureofPatientName:"",naturecode:"",typeinsurance:"",hospitallogo:"",status:"",natureTypeCard:"",medicaltype:"",remarks:"",concurrencyStamp:"",creationTime:"",creatorId:"",lastModificationTime:"",lastModifierId:"",isDeleted:!1,deleterId:"",deletionTime:""}),T=()=>{w.addConfing(U.value).then((()=>{k.value=!1,C()}))};return(e,a)=>{const t=v,P=_,E=V,N=g,S=b,$=y,I=j,A=h,F=f;return r(),o(c,null,[d(t,{type:"danger",onClick:a[0]||(a[0]=e=>k.value=!0)},{default:i((()=>a[11]||(a[11]=[n("新增病人性质")]))),_:1}),d(t,{type:"primary",onClick:C},{default:i((()=>a[12]||(a[12]=[n("修改")]))),_:1}),d(P,{modelValue:e.searchValue,"onUpdate:modelValue":a[1]||(a[1]=l=>e.searchValue=l),placeholder:"请输入搜索内容",clearable:"",style:{width:"300px"},onChange:e.search},null,8,["modelValue","onChange"]),d(t,{type:"primary",onClick:C},{default:i((()=>a[13]||(a[13]=[n("搜索")]))),_:1}),d(N,{data:m(l),border:"",style:{width:"100%"},onSelectionChange:e.handleSelectionChange},{default:i((()=>[d(E,{type:"selection",width:"55"}),d(E,{prop:"natureofPatientName",label:"患者性质",width:"180"}),d(E,{prop:"naturecode",label:"编码",width:"180"}),d(E,{prop:"hospitallogo",label:"门诊住院标志",width:"180"}),d(E,{prop:"natureTypeCard",label:"性质类别卡",width:"180"}),d(E,{prop:"medicaltype",label:"以保险标准",width:"180"}),d(E,{prop:"remarks",label:"备注",width:"180"}),d(E,{prop:"creationTime",label:"创建时间"},{default:i((({row:e})=>[u("span",null,s(e.creationTime.slice(0,10)),1)])),_:1}),d(E,{label:"操作",width:"180"},{default:i((({row:e})=>[d(t,{type:"danger",onClick:l=>{return a=e.id,void w.deleteConfig(a).then((()=>{C()})).catch((e=>{}));var a}},{default:i((()=>a[14]||(a[14]=[n("删除")]))),_:2},1032,["onClick"])])),_:1})])),_:1},8,["data","onSelectionChange"]),d(F,{modelValue:m(k),"onUpdate:modelValue":a[10]||(a[10]=e=>p(k)?k.value=e:null),title:"新建病人性质",width:"500",draggable:"",overflow:""},{footer:i((()=>[u("div",x,[d(t,{type:"primary",onClick:T},{default:i((()=>a[15]||(a[15]=[n("确定")]))),_:1}),d(t,{type:"danger",onClick:a[9]||(a[9]=e=>k.value=!1)},{default:i((()=>a[16]||(a[16]=[n("关闭")]))),_:1})])])),default:i((()=>[a[17]||(a[17]=u("span",null,"基本信息",-1)),d(A,{model:m(U)},{default:i((()=>[d(S,{label:"性质名称：\t"},{default:i((()=>[d(P,{modelValue:m(U).natureofPatientName,"onUpdate:modelValue":a[2]||(a[2]=e=>m(U).natureofPatientName=e),placeholder:"请输入名称",clearable:""},null,8,["modelValue"])])),_:1}),d(S,{label:"性质代码"},{default:i((()=>[d(P,{modelValue:m(U).naturecode,"onUpdate:modelValue":a[3]||(a[3]=e=>m(U).naturecode=e),placeholder:"请输入性质代码",clearable:""},null,8,["modelValue"])])),_:1}),d(S,{label:"医保险种类型"},{default:i((()=>[d(P,{modelValue:m(U).typeinsurance,"onUpdate:modelValue":a[4]||(a[4]=e=>m(U).typeinsurance=e),placeholder:"请输入医保",clearable:""},null,8,["modelValue"])])),_:1}),d(S,{label:"门诊住院标志"},{default:i((()=>[d(I,{modelValue:m(U).hospitallogo,"onUpdate:modelValue":a[5]||(a[5]=e=>m(U).hospitallogo=e)},{default:i((()=>[d($,{label:"通用",value:"通用"}),d($,{label:"仅门诊",value:"仅门诊"}),d($,{label:"仅住院",value:"仅住院"}),d($,{label:"系统",value:"系统"})])),_:1},8,["modelValue"])])),_:1}),d(S,{label:"状态"},{default:i((()=>[d(I,{modelValue:m(U).status,"onUpdate:modelValue":a[6]||(a[6]=e=>m(U).status=e)},{default:i((()=>[d($,{label:"启用",value:"启用"}),d($,{label:"停用",value:"停用"})])),_:1},8,["modelValue"])])),_:1}),d(S,{label:"性质类别(卡)"},{default:i((()=>[d(I,{modelValue:m(U).natureTypeCard,"onUpdate:modelValue":a[7]||(a[7]=e=>m(U).natureTypeCard=e)},{default:i((()=>[d($,{label:"自费",value:"自费"}),d($,{label:"医保",value:"医保"})])),_:1},8,["modelValue"])])),_:1}),d(S,{label:"医保交易类型"},{default:i((()=>[d(I,{modelValue:m(U).medicaltype,"onUpdate:modelValue":a[8]||(a[8]=e=>m(U).medicaltype=e)},{default:i((()=>[d($,{label:"不交易",value:"不交易"}),d($,{label:"普通交易",value:"普通交易"}),d($,{label:"大病交易",value:"大病交易"})])),_:1},8,["modelValue"])])),_:1})])),_:1},8,["model"])])),_:1},8,["modelValue"])],64)}}});export{k as default};
