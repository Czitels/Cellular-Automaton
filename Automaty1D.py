import pygame
import json


class Cell:

    def __init__(self, condition):
        self.condition = condition


def main():
    with open('config.json') as json_data_file:
        data = json.load(json_data_file)
    p = data['configs']

    rule = p['rule']
    time = p['time']
    size = p['size']

    vectorOfCells = [Cell(0) for count in range(size)]
    newVector = [Cell(0) for count in range(size)]

    vectorOfCells[int(size/2)].condition = 1
    newVector[int(size/2)].condition = 1

    pygame.init()

    width = 1000
    height = 600

    screen = pygame.display.set_mode((width, height))
    done = False
    x = 0
    y = 0
    j = 0

    cwidth = int(width/size)
    cheight = int(height/size)

    if(cwidth < cheight):
        cheight=cwidth
    elif(cwidth > cheight):
        cwidth=cheight

    while not done:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                done = True
        if j < time:
            for i in range(len(newVector)):
                if newVector[i].condition == 0:
                    pygame.draw.rect(screen, (255, 255, 255), pygame.Rect(x, y, cwidth, cheight))
                else:
                    pygame.draw.rect(screen, (0, 0, 0), pygame.Rect(x, y, cwidth, cheight))
                newVector[i].condition = 0
                x += cwidth+2
            y += cheight+2
            x = 0

            for i in range(len(vectorOfCells)):
                if rule == 30:
                    if ~(i == 0) and (i < len(vectorOfCells) - 1):
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                    elif i == 0:
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 1
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 0
                    elif i == len(vectorOfCells) - 1:
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 0:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 1
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 0
                if rule == 60:
                    if ~(i == 0) and (i < len(vectorOfCells) - 1):
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                    elif i == 0:
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 1
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            else:
                                newVector[i].condition = 0
                    elif i == len(vectorOfCells) - 1:
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 0:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 1
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 0
                            else:
                                newVector[i].condition = 0
                if rule == 90:
                    if ~(i == 0) and (i < len(vectorOfCells) - 1):
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                    elif i == 0:
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 0
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 0
                    elif i == len(vectorOfCells) - 1:
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 0
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 0
                if rule == 120:
                    if ~(i == 0) and (i < len(vectorOfCells) - 1):
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                    elif i == 0:
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 0
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            else:
                                newVector[i].condition = 0
                    elif i == len(vectorOfCells) - 1:
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 1
                            else:
                                newVector[i].condition = 0
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 0
                            else:
                                newVector[i].condition = 0
                if rule == 225:
                    if ~(i == 0) and (i < len(vectorOfCells) - 1):
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                    elif i == 0:
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            else:
                                newVector[i].condition = 0
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 1 and vectorOfCells[i + 1].condition == 0:
                                newVector[i].condition = 0
                            elif vectorOfCells[len(vectorOfCells) - 1].condition == 0 and vectorOfCells[i + 1].condition == 1:
                                newVector[i].condition = 0
                            else:
                                newVector[i].condition = 1
                    elif i == len(vectorOfCells) - 1:
                        if vectorOfCells[i].condition == 1:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 0:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 0
                            else:
                                newVector[i].condition = 0
                        elif vectorOfCells[i].condition == 0:
                            if vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 1
                            elif vectorOfCells[i - 1].condition == 1 and vectorOfCells[0].condition == 0:
                                newVector[i].condition = 0
                            elif vectorOfCells[i - 1].condition == 0 and vectorOfCells[0].condition == 1:
                                newVector[i].condition = 0
                            else:
                                newVector[i].condition = 1

        for i in range(len(newVector)):
            vectorOfCells[i].condition = newVector[i].condition
        j=j+1
        pygame.display.flip()



if __name__ == '__main__':
    main()
