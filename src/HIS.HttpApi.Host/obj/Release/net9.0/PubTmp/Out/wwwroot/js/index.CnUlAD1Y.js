import{f as e}from"./vnode.BzFWtM5t.js";import{s as r,c4 as o}from"./index.ZLNrSxa7.js";const t=(t,i)=>{const n={},a=r([]);return{children:a,addChild:r=>{n[r.uid]=r,a.value=((r,t,i)=>e(r.subTree).filter((e=>{var r;return o(e)&&(null==(r=e.type)?void 0:r.name)===t&&!!e.component})).map((e=>e.component.uid)).map((e=>i[e])).filter((e=>!!e)))(t,i,n)},removeChild:e=>{delete n[e],a.value=a.value.filter((r=>r.uid!==e))}}};export{t as u};
