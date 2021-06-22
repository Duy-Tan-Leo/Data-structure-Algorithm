class Array(object):
    def __init__(self, size, arrayType=int):
        self.sizeOfArray = len(list(map(arrayType, range(size))))
        self.arrayItem = [arrayType(0)] * size
        self.arrayType = arrayType

    def __str__(self):
        return " ".join([str(i) for i in self.arrayItem])

    def __setItem__(self, index, data):
        self.arrayItem[index] = data

    def __getItem__(self, index):
        return self.arrayItem[index]

    def __search__(self, keyToSearch):
        for i in range(self.sizeOfArray):
            if(self.arrayItem[i] == keyToSearch):
                return 1
        return -1

    # Index start with 0
    def insert(self, index, value):
        self.arrayItem = self.arrayItem + [self.arrayType(0)]
        if(index < self.sizeOfArray):
            for i in range(self.sizeOfArray - 1, index, -1):
                self.arrayItem
                self.arrayItem[i + 1] = self.arrayItem[i]
            self.arrayItem[i] = value

    # Index start with 0
    def delete(self, value):
        deleted = True
        for i in range(self.sizeOfArray - 1):
            if(self.arrayItem[i] == value):
                deleted = False
                self.arrayItem = self.arrayItem[:i-1] + self.arrayItem[i+1:]
                break

        if deleted:
            print("Can't delete because the provided data doeasn't exit")


if __name__ == '__main__':
    a = Array(10, int)
    print(a)

    a.insert(2, 2)
    print("List after insert 2 : ", a)

    a.delete(2)
    print("List after delete 2 : ", a)
    a.delete(3)
    print("List after delete 3 : ", a)
