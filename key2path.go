package main

import (
	"crypto/sha1"
	"encoding/base64"
	"encoding/hex"
	"fmt"
	"io"
)

func main() {

	for {
		var key string
		fmt.Print("input raw key: ")
		fmt.Scanf("%s", &key)

		bkKey := base64.URLEncoding.EncodeToString([]byte(key))

		h := sha1.New()
		io.WriteString(h, bkKey)
		sha1Key := h.Sum(nil)

		hexKey := hex.EncodeToString(sha1Key)

		dir1st := hexKey[0:2]

		dir2nd := hexKey[2:4]

		fmt.Println("\tkey:", key)
		fmt.Println("\tbkKey:", bkKey)
		fmt.Println("\tsha1Key:", sha1Key)
		fmt.Println("\thexKey:", hexKey)
		fmt.Println("\tdir1st:", dir1st)
		fmt.Println("\tdir2nd:", dir2nd)
		fmt.Printf("path: qrsb_dir/data/%s/%s/%s\n\n", dir1st, dir2nd, bkKey)
	}
}
