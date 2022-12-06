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

	slice := strings.TrimRight(strings.ReplaceAll(string(input), "\r", ""), "\n") //ToArray

	var mostKcal int
	for _, elfFood := range strings.Split(slice, "\n\n") {
		var totalElfKcal int
		for _, foodItem := range strings.Split(elfFood, "\n") {
			if kcal, err := strconv.Atoi(foodItem); err == nil {
				totalElfKcal += kcal
			} else {
				fmt.Println()
				panic(err) // just for tests
			}
		}
		if totalElfKcal > mostKcal {
			mostKcal = totalElfKcal
		}
	}

	fmt.Println(mostKcal)
}
