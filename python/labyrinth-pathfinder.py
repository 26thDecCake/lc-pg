import curses
from curses import wrapper
import queue
import random
import time

# labyrinth = [
#   ["#", "S", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"],
#   ["#", " ", " ", " ", "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", "#"],
#   ["#", "#", "#", " ", "#", " ", "#", "#", "#", " ", "#", " ", "#", " ", "#"],
#   ["#", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", "#", " ", "#"],
#   ["#", "#", "#", "#", "#", "#", "#", "#", "#", " ", "#", " ", "#", " ", "#"],
#   ["#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", "#"],
#   ["#", "#", "#", " ", "#", "#", " ", "#", "#", "#", "#", "#", " ", "#", "#"],
#   ["#", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#"],
#   ["#", "#", "#", "#", "#", "#", "#", "#", "X", "#", "#", "#", "#", "#", "#"]
# ]

def generate_labyrinth(width, height):
    labyrinth = [["#" for _ in range(width)] for _ in range(height)]

    # Start and end points
    start_x, start_y = random.randint(1, width - 2), random.randint(1, height - 2)
    end_x, end_y = random.randint(1, width - 2), random.randint(1, height - 2)

    labyrinth[start_y][start_x] = "S"
    labyrinth[end_y][end_x] = "X"

    # Generate paths recursively
    def generate(x, y):
        directions = [(1, 0), (-1, 0), (0, 1), (0, -1)]
        random.shuffle(directions)
        for dx, dy in directions:
            nx, ny = x + dx * 2, y + dy * 2
            if 0 <= nx < width and 0 <= ny < height and labyrinth[ny][nx] == "#":
                labyrinth[y + dy][x + dx] = " "
                labyrinth[ny][nx] = " "
                generate(nx, ny)

    # Generate paths from start point
    generate(start_x, start_y)

    # Remove some walls randomly to create branches or dead ends
    for _ in range(width * height // 3):
        x, y = random.randint(1, width - 2), random.randint(1, height - 2)
        if labyrinth[y][x] == "#":
            labyrinth[y][x] = " "

    return labyrinth

def ensure_path(labyrinth, start_x, start_y, end_x, end_y):
    queue = [(start_x, start_y)]
    visited = set()
    while queue:
        x, y = queue.pop(0)
        if (x, y) == (end_x, end_y):
            return
        visited.add((x, y))
        for dx, dy in [(1, 0), (-1, 0), (0, 1), (0, -1)]:
            nx, ny = x + dx, y + dy
            if 0 <= nx < len(labyrinth[0]) and 0 <= ny < len(labyrinth) and labyrinth[ny][nx] == " " and (nx, ny) not in visited:
                queue.append((nx, ny))

    # If there's no path from start to end, create one
    for y in range(len(labyrinth)):
        for x in range(len(labyrinth[0])):
            if labyrinth[y][x] == " " and (x, y) not in visited:
                labyrinth[y][x] = "#"
                ensure_path(labyrinth, start_x, start_y, end_x, end_y)
                return

# Size of the labyrinth
width = 18
height = 10

random_labyrinth = generate_labyrinth(width, height)
start_x, start_y = 1, 1
end_x, end_y = width - 2, height - 2

ensure_path(random_labyrinth, start_x, start_y, end_x, end_y)


def print_labyrinth(random_labyrinth, stdscr, path=[]):
    RED = curses.color_pair(2)
    BLUE = curses.color_pair(1)

    for i, row in enumerate(random_labyrinth):
        for j, value in enumerate(row):
            if (i, j) in path:
                stdscr.addstr(i, j*2, "X", BLUE)
            else:
                stdscr.addstr(i, j*2, value, RED)


def find_start(random_labyrinth, start):
    for i, row in enumerate(random_labyrinth):
        for j, value in enumerate(row):
            if value == start:
                return i, j

    return None


def find_path(random_labyrinth, stdscr):
    start = "S"
    end = "X"
    start_pos = find_start(random_labyrinth, start)

    q = queue.Queue()
    q.put((start_pos, [start_pos]))

    visited = set()

    while not q.empty():
        current_pos, path = q.get()
        row, col = current_pos

        stdscr.clear()
        print_labyrinth(random_labyrinth, stdscr, path)
        time.sleep(0.2)
        stdscr.refresh()

        if random_labyrinth[row][col] == end:
            return path

        neighbors = find_neighbors(random_labyrinth, row, col)
        for neighbor in neighbors:
            if neighbor in visited:
                continue

            r, c = neighbor
            if random_labyrinth[r][c] == "#":
                continue

            new_path = path + [neighbor]
            q.put((neighbor, new_path))
            visited.add(neighbor)


def find_neighbors(random_labyrinth, row, col):
    neighbors = []

    if row > 0:  # UP
        neighbors.append((row - 1, col))
    if row + 1 < len(random_labyrinth):  # DOWN
        neighbors.append((row + 1, col))
    if col > 0:  # LEFT
        neighbors.append((row, col - 1))
    if col + 1 < len(random_labyrinth[0]):  # RIGHT
        neighbors.append((row, col + 1))

    return neighbors


def main(stdscr):
    curses.init_pair(1, curses.COLOR_BLUE, curses.COLOR_BLACK)
    curses.init_pair(2, curses.COLOR_RED, curses.COLOR_BLACK)

    find_path(random_labyrinth, stdscr)
    stdscr.getch()


wrapper(main)