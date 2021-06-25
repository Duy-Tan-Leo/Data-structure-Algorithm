
if __name__ == "__main__":
    def digital_root(n):
        n = str(n)
        sum = int(n[0])
        if len(n) > 2:
            sum += int(n[1]) + digital_root(n[2:])
        elif len(n) == 2:
            sum += int(n[1])
        if sum >= 10:
            sum = digital_root(sum)
        return sum 

    a = 30 or 19
    b = 19 and 9
    print(a or b)