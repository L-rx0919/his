import{d as t,ap as e,e as o,f as s,w as a,l,m as n,E as r,k as c,aC as i}from"./index.ZLNrSxa7.js";import{E as u}from"./el-button.DSrO3PCY.js";const p=t({name:"CopyButton",inheritAttrs:!1,__name:"index",props:{text:{type:String,default:""},style:{type:Object,default:()=>({})}},setup(t){const p=t;function d(){if(navigator.clipboard&&navigator.clipboard.writeText)navigator.clipboard.writeText(p.text).then((()=>{i.success("Copy successfully")})).catch((t=>{i.warning("Copy failed")}));else{const e=document.createElement("input");e.style.position="absolute",e.style.left="-9999px",e.setAttribute("value",p.text),document.body.appendChild(e),e.select();try{document.execCommand("copy")?i.success("Copy successfully!"):i.warning("Copy failed!")}catch(t){i.error("Copy failed.")}finally{document.body.removeChild(e)}}}return(i,p)=>{const y=e("DocumentCopy"),f=r,m=u;return s(),o(m,{link:"",style:c(t.style),onClick:d},{default:a((()=>[l(i.$slots,"default",{},(()=>[n(f,null,{default:a((()=>[n(y,{color:"var(--el-color-primary)"})])),_:1})]))])),_:3},8,["style"])}}});export{p as _};
