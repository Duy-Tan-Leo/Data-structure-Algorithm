from DoublelyLinkedList import *


class Node(DoubleLinkListNode):
    def __init__(self, firstNode=None, lastNode=None):
        DoubleLinkListNode.__init__(self, firstNode, lastNode)


class CircleLinkedList(DoublelyLinkedList):
    def __init__(self, next_circle_node=None, prv_circle_node=None):
        self.lastNode = Node(next_circle_node)
        self.headNode = Node(prv_circle_node)

    def addFirstNode(self, value):
        newNode = Node(value)
        self.lastNode = newNode
        self.headNode = newNode
        self.before = newNode

    def getFirstItem(self):
        return str(self.headNode.get_value())

    def getLastItem(self):
        return str(self.lastNode.get_value())

    def updateHeadTailList(self):
        lastNode = self.before
        self.lastNode = lastNode

        while lastNode.last != None:
            lastNode = lastNode.last
        self.headNode = lastNode

    def insertAtFirst(self, value):
        DoublelyLinkedList.insertFirst(self, value)
        self.headNode = self.before

    def insertAtLast(self, value):
        newNode = Node(value)
        # get last node from list
        lastNode = self.lastNode

        # update last node
        lastNode.last = newNode
        newNode.first = lastNode

        # Update the last node of list
        self.lastNode = newNode

    def printList(self):
        return super().printList()


if __name__ == "__main__":
    circleLinkedList = CircleLinkedList()

    circleLinkedList.addFirstNode(0)

    for i in range(1, 10, 1):
        circleLinkedList.insertAtFirst(i)
        circleLinkedList.insertAtLast(i)
        print("insert into 2 sidés")
        circleLinkedList.printList()
