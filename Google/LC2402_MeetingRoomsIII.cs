using System;
using System.Collections.Generic;

// https://leetcode.com/problems/meeting-rooms-iii/discuss/2531303/C-two-heaps-solution

public class Solution2402 {

    public static int MostBooked(int n, int[][] meetings) {
        
        var roomCount = new Dictionary<int, int>();
        var emptyRooms = new PriorityQueue<int, int>();
        var occupiedRooms = new PriorityQueue<int, long>();

        for (var i = 0; i < n; i++) {
            roomCount[i] = 0;
            emptyRooms.Enqueue(i, i);
        }

        Array.Sort(meetings, (x, y) => x[0].CompareTo(y[0]));

        foreach (int[] aMeeting in meetings) {

            int roomOut;
            long endTimeOut;

            while (occupiedRooms.TryPeek(out roomOut, out endTimeOut)) {
                if ((long)aMeeting[0] >= endTimeOut) {
                    occupiedRooms.Dequeue();
                    emptyRooms.Enqueue(roomOut, roomOut);
                } else {
                    break;
                }
            }

            int room = -1;
            if (emptyRooms.Count > 0) {
                room = emptyRooms.Dequeue();
                occupiedRooms.Enqueue(room, (long)aMeeting[1]);
                roomCount[room]++;
                continue;
            }

            occupiedRooms.TryDequeue(out roomOut, out endTimeOut);
            emptyRooms.Enqueue(roomOut, roomOut);

            while (occupiedRooms.TryPeek(out int roomOutNext, out long endTimeOutNext)) {
                if (endTimeOut == endTimeOutNext) {
                    emptyRooms.Enqueue(roomOutNext, roomOutNext);
                    occupiedRooms.Dequeue();
                } else {
                    break;
                }
            }

            room = emptyRooms.Dequeue();
            occupiedRooms.Enqueue(room, (long)aMeeting[1] + (endTimeOut - (long)aMeeting[0]));
            roomCount[room] ++;
        }

        int maxCount = 0;
        int maxRoomNumber = -1;
        for (int i = 0; i < n; i++) {

            Console.WriteLine($"Room# {i}; Count {roomCount[i]}");

            if (roomCount[i] > maxCount) {
                maxCount = roomCount[i];
                maxRoomNumber = i;
            }
        }

        return maxRoomNumber;
    }

    public static void main1(){
        
        int[][] meetings = new int[5][];
        meetings[0] = new int[2]{1,20};
        meetings[1] = new int[2]{2,10};
        meetings[2] = new int[2]{3,5};
        meetings[3] = new int[2]{4,9};
        meetings[4] = new int[2]{6,8};

        /*int[][] meetings = new int[4][];
        meetings[0] = new int[2]{0,10};
        meetings[1] = new int[2]{1,5};
        meetings[2] = new int[2]{2,7};
        meetings[3] = new int[2]{3,4};*/


        Console.WriteLine(MostBooked(3, meetings));
    }
}