const fs = require('fs');
const path = require('path');
const { sha3_256 } = require('js-sha3');

// Step 1: Your email (in lowercase)
const email = 'contact.masumkazi@gmail.com'.toLowerCase();

// Step 2: Folder where `.data` files are stored
const filesDir = path.join(__dirname, 'task2');

// Step 3: Read all filenames in the folder
const filenames = fs.readdirSync(filesDir);

// Step 4: Calculate SHA3-256 hash of each file
const hashes = filenames.map((filename) => {
  const filePath = path.join(filesDir, filename);
  const fileBuffer = fs.readFileSync(filePath); // Read as binary
  const hash = sha3_256(fileBuffer); // 64 lowercase hex digits
  return hash;
});

// Step 5: Sort the hashes in **descending** order
hashes.sort().reverse();

// Step 6: Join all hashes (no separator)
const joinedHashes = hashes.join('');

// Step 7: Append your email at the end
const finalString = joinedHashes + email;

// Step 8: SHA3-256 of final string
const finalHash = sha3_256(finalString);

// Step 9: Output the command for Discord
console.log(`!task2 ${email} ${finalHash}`);
