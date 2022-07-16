
"""
We do a breadth first search starting from each of the deficient nodes
and find the nearest centre with surplus supply and the evaluate the maximum 
of these values
"""

def findMinimumTime(center_nodes,center_from,center_to,status):
    #to keep track of the minimum time
    min_dist=0
    #iterate through each node
    for i in range(center_nodes):
        #do bfs from each node
        if status[i]==1:
            s_node=i+1 #starting node for bfs
            dist=0 #
            queue=[(s_node,dist)] #queue for bfs
            visited=[False for k in range(center_nodes)] #to keep a list of visited nodes

            #do bfs
            while(len(queue)!=0):
                cur_node,cur_dist=queue[0]
                visited[cur_node-1]=True
                queue.pop(0)
                #if a centre has surplus then stop the search
                if status[cur_node-1]==3:
                    dist=cur_dist
                    break
                for j in range(len(center_from)):
                    if center_from[j]==cur_node and not visited[center_to[j]-1]:
                        queue.append((center_to[j],cur_dist+1))
                    elif center_to[j]==cur_node and not visited[center_from[j]-1]:
                        queue.append((center_from[j],cur_dist+1))
    
            min_dist=max(dist,min_dist)
    return min_dist

print(findMinimumTime(3,[1,2],[2,3],[1,2,3]))