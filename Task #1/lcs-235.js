let args=process.argv.slice(2),longest='';
args.length&&[...args[0]].forEach((_,i)=>{for(let j=i+1,s;j<=args[0].length;j++)s=args[0].slice(i,j),args.every(a=>a.includes(s))&&s.length>longest.length&&(longest=s)});
console.log(longest);