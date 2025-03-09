let args=process.argv.slice(2),longest='';
if (args.length) {
  const first = args[0];
  for (let i = 0; i < first.length; i++) {
    for (let j = i + 1; j <= first.length; j++) {
      const substr = first.slice(i, j);
      if (args.every(arg => arg.includes(substr))) {
        longest=substr.length>longest.length?substr:longest;
      }
    }
  }
}
console.log(longest);
