package main

import (
	"fmt"
	"log"
	"os"
	"strconv"
	"strings"
)

func main() {
	//Check if the file exists and read it
	input, err := os.ReadFile("input.txt")
	if err != nil {
		log.Fatalf("could not read input file: %s", err)
	}

	str1 := string(input[:])                                              //ToString
	array1 := strings.Split(strings.ReplaceAll(str1, "\r\n", "\n"), "\n") //ToArray

	var sumedUpArray []int
	calSum := 0
	for i := 0; i <= len(array1)-1; i++ {
		if array1[i] != "" {
			temp, err := strconv.Atoi(array1[i]) //String to int
			if err != nil {
				log.Fatalf("invalid input: %s", err)
			}

			calSum = calSum + temp
		} else {
			sumedUpArray = append(sumedUpArray, calSum)
			calSum = 0
		}
	}

	var temp, largerNumber int
	for _, element := range sumedUpArray {
		if element > temp {
			temp = element
			largerNumber = temp
		}
	}

	fmt.Println(largerNumber)
}

// func printSlice(s []int) {
// 	fmt.Printf("len=%d cap=%d %v\n", len(s), cap(s), s)
// }
