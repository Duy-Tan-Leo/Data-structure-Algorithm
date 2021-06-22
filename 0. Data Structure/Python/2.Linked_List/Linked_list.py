class Node(object):
    def __init__(self, value):
        self.data = value
        self.next = None

class LinkedList(object):
    def __init__(self):
        self.head = None

    def set_next(self, newNode):
        self.next = newNode

    def printList(self):
        temp = self.head
        print("\n")
        while(temp):
            print(temp.data, end=" ")
            temp = temp.next

    def search(self, value):
        temp = self.head
        while temp.data:
            if temp.data == value:
                return True
            temp = temp.next
        return False

    def insertBetween(self, toInsertNode, insertedValue):
        if(toInsertNode.next is None):
            print("Current node doesn't have next node")
        else:
            newNode = Node(insertedValue)
            newNode.next = toInsertNode.next
            toInsertNode.next = newNode

    def delete(self, deletedValue):
        current = self.head
        pre = Node(0)
        if(current.data == deletedValue):
            self.head = self.head.next
        else:
            while current.data:
                current = current.next 
                if current.data == deletedValue:
                    pre.next = current.next
                    break
                pre = current

    def append(self, insertValue):
        temp = self.head
        while temp.next != None:
            temp = temp.next
        temp.next = Node(insertValue)
    
    def insertAtBegin(self, insertValue):
        temp = self.head
        self.head = Node(insertValue)
        self.head.next = temp     
        
if __name__ == "__main__":
    linkList = LinkedList()
    linkList.head = Node(1)

    node2 = Node(2)
    node3 = Node(3)
    
    linkList.head.next = node2
    node2.next = node3

    linkList.insertBetween(node2,10)
    linkList.printList()

    linkList.delete(10)
    print("After delete: " )
    linkList.printList()

    linkList.insertAtBegin(10)
    print("Insert at head " )
    
    linkList.append(100)
    print("Insert at tail " )
    linkList.printList()
