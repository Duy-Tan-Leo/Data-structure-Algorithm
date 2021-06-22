
class DoubleLinkListNode(object):
    def __init__(self, value, firstNode=None, lastNode=None):
        self.first = firstNode
        self.data = value
        self.last = lastNode

    def get_value(self):
        return self.data

    def setNext(self, nextNode):
        self.last = nextNode

    def setBefore(self, beforeNode):
        self.first = beforeNode


class DoublelyLinkedList:
    def __init__(self):
        self.before = None

    def printList(self):
        temp = self.before
        while temp.data is not None:
            print(temp.data, end=" ")
            if(temp.last is None):
                break
            temp = temp.last

    def insertLast(self, nextNode):
        temp = self.before
        while temp.last != None:
            temp = temp.last
        newNode = DoubleLinkListNode(nextNode)
        newNode.first = temp
        temp.last = newNode

    def insertFirst(self, firstNode):
        newNode = DoubleLinkListNode(firstNode)
        temp = self.before
        newNode.last = temp
        self.before = newNode


if __name__ == "__main__":
    doublelyLinkedList = DoublelyLinkedList()
    node_a = DoubleLinkListNode(1)
    doublelyLinkedList.before = node_a

    doublelyLinkedList.insertFirst(10)
    print("insert to head the value of 10 \n")
    doublelyLinkedList.printList()
    
    doublelyLinkedList.insertLast(2)
    print("insert to tail the value of 2 \n")
    doublelyLinkedList.printList()
    
    doublelyLinkedList.insertFirst(9)
    print("insert to head the value of 9 \n")
    doublelyLinkedList.printList()
    
    doublelyLinkedList.insertLast(3)
    print("insert to tail the value of 3 \n")
    # doublelyLinkedList.insertFirst(10)
    # doublelyLinkedList.insertLast(12)
    doublelyLinkedList.printList()
