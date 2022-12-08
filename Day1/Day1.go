package main

import (
	"fmt"
	"log"
	"os"
	"sort"
	"strconv"
	"strings"
)

func main() {
	part1()
	part2()
}

func part1() {
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

	fmt.Println("Part 1 answer is: " + strconv.Itoa(mostKcal))
}

func part2() {
	//Check if the file exists and read it
	input, err := os.ReadFile("input.txt")
	if err != nil {
		log.Fatalf("could not read input file: %s", err)
	}

	slice := strings.TrimRight(strings.ReplaceAll(string(input), "\r", ""), "\n") //ToArray

	var sumedUpKcal []int
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
		sumedUpKcal = append(sumedUpKcal, totalElfKcal)
	}

	//Ordey by descending
	sort.Slice(sumedUpKcal, func(i, j int) bool {
		return sumedUpKcal[i] > sumedUpKcal[j]
	})

	var threeMostKcal int
	for i := 0; i < 3; i++ {
		threeMostKcal += sumedUpKcal[i]
	}

	fmt.Println("Part 2 answer is: " + strconv.Itoa(threeMostKcal))
}
